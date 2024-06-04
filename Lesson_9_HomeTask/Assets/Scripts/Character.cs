using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    private bool isGrounded;
    private bool prohibitMotion;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private int health;
    [SerializeField] private int lives;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float swordColliderX = 1.2f;
    [SerializeField] private float swordColliderY = -0.03f;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI continueGame;

    public AudioSource source;
    public AudioClip jumpSound;
    public AudioClip injureSound;
    public AudioClip swordSound;

    int heroHealth;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animator;
    NinjaControl controller;

    public GameObject hitCollider;

    public Animator Animator { get { return animator = animator ?? GetComponent<Animator>(); } }
    public SpriteRenderer SpriteRenderer { get { return sprite = sprite ?? GetComponent<SpriteRenderer>(); } }
    public Rigidbody2D RB { get { return rb = rb ?? GetComponent<Rigidbody2D>(); } }
    private void OnEnable()
    {
        controller = new NinjaControl();
        controller.NinjaMap.Jump.performed += Jump_performed;
        controller.NinjaMap.Fight.performed += Fight_performed;
        controller.NinjaMap.Continue.performed += Continue_performed;
        controller.Enable();
    }

    

    private void OnDisable()
    {
        controller.NinjaMap.Jump.performed -= Jump_performed;
        controller.NinjaMap.Fight.performed -= Fight_performed;
        controller.NinjaMap.Continue.performed -= Continue_performed;
        controller.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        heroHealth = health;
        livesText.text = $"Lives - {lives}";
        healthText.text = $"Health - {heroHealth}";
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded) Animator.SetTrigger("Jump");
        Vector3 direction = controller.NinjaMap.Motion.ReadValue<Vector2>();
        if (!prohibitMotion)
        {
            Move(direction);
        }
        
    }
    void Move(Vector3 direction) 
    {
        Debug.Log("isGrounded = " + isGrounded);
        if (direction.x > 0)
        {
            hitCollider.transform.localPosition = new Vector2(swordColliderX, swordColliderY);
            SpriteRenderer.flipX = false;
            if (isGrounded) Animator.SetTrigger("Run");
        }
        if (direction.x < 0)
        {
            hitCollider.transform.localPosition = new Vector2(-swordColliderX, swordColliderY);
            SpriteRenderer.flipX = true;
            if (isGrounded) Animator.SetTrigger("Run");
        }
        if (direction.x == 0)
        {
            if (isGrounded) Animator.SetTrigger("Idle");
        }
        RB.transform.position = Vector3.MoveTowards(RB.transform.position, RB.transform.position + direction, speed * Time.deltaTime);
        
    }
    private void Fight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (isGrounded)
        {
            Animator.SetTrigger("Attack");
        }
        else if (!isGrounded)
        {
            Animator.SetTrigger("AttackJumping");
        }
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (isGrounded && !prohibitMotion)
        {
            source.PlayOneShot(jumpSound);
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    public void GetDamage(int damageDegree) 
    {
        source.PlayOneShot(injureSound);
        if (heroHealth > 0)
        {
            heroHealth -= damageDegree;
            if (heroHealth < 0) { heroHealth = 0; }
            livesText.text = $"Lives - {lives}";
            healthText.text = $"Health - {heroHealth}";
            Animator.SetTrigger("Hurt");
        }
        else
        {
            if (lives > 0)
            {
                lives -= 1;
                heroHealth = health;
                livesText.text = $"Lives - {lives}";
                healthText.text = $"Health - {heroHealth}";
                Animator.SetTrigger("Dead");
                Animator.SetTrigger("ReSpawn");
            }
            else 
            {
                Animator.SetTrigger("Finish");
                Debug.Log("You're dead");
                livesText.text = $"Lives - {lives}";
                healthText.text = $"Health - {heroHealth}";
                prohibitMotion = true;
                continueGame.gameObject.SetActive(true);
            }
        }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("isGrounded = " + isGrounded);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
    }

    void StartAttack()
    {
        hitCollider.SetActive(true);
        source.PlayOneShot(swordSound);
    }
    void EndAttack()
    {
        hitCollider.SetActive(false);
    }
    void StartHurt()
    {
        prohibitMotion = true;
    }
    void FinishHurt()
    {
        prohibitMotion = false;
    }
    void StartFallDown() 
    {
        prohibitMotion = true;
    }
    void AbleToWalk() 
    {
        prohibitMotion = false;
    }

    private void Continue_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (continueGame.isActiveAndEnabled) 
        {
            heroHealth = health;
            lives++;
            prohibitMotion = false;
            Animator.SetTrigger("ReSpawn");
            continueGame.gameObject.SetActive(false);
        }
    }
}
