using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.XR;

public class PlayerControll : MonoBehaviour
{
    public int health;
    public float moveSpeed = 2.0f;
    public float sprintSpeed = 7.0f;
    float moveBackwardsSpeed = 1.0f;
    float yRotation;
    float jumpHeight = 10.0f;
    float gravity = -9.81f;
    bool isRunning;
    bool isJumping = false;
    bool isAlive = true;
    public float animationBlendSpeed = 0.2f;
    float targetAnimationSpeed = 0.0f;
    float velocityY;
    bool prohibitMotion;
    bool prohibitRotation;
    public List<Rigidbody> bodies;

    private NewControls inputManager;
    CharacterController characterController;
    public Camera characterCamera;
    Animator animator;
    public CharacterController CharacterController { get { return characterController = characterController ?? GetComponent<CharacterController>(); } }
    public Animator Animator { get { return animator = animator ?? GetComponent<Animator>(); } }
    public List<string> punches;

    private void OnEnable()
    {
        inputManager = new NewControls();
        inputManager.CharacterMap.Jump.performed += Jump_performed;
        inputManager.CharacterMap.Fight.performed += Fight_performed;
        inputManager.CharacterMap.Dead.performed += Dead_performed;
        inputManager.Enable();
    }

    

    private void OnDisable()
    {
        inputManager.CharacterMap.Jump.performed -= Jump_performed;
        inputManager.CharacterMap.Fight.performed -= Fight_performed;
        inputManager.CharacterMap.Dead.performed -= Dead_performed;
        inputManager.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = inputManager.CharacterMap.Motion.ReadValue<Vector2>().normalized;
        if (CharacterController != null)
        {
            Move(direction);
        }
        Rotation();
        
        if (CharacterController != null && !CharacterController.isGrounded)
        {
            velocityY += gravity * Time.deltaTime;
        }
        else if (velocityY < 0.0f)
        {
            velocityY = 0.0f;
        }

        if (isJumping & velocityY < 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, LayerMask.GetMask("Default")))
            {
                isJumping = false;
                Animator.SetTrigger("Landing");
            }
        }
    }
    private void Dead_performed(InputAction.CallbackContext obj)
    {
        Die();
    }

    void Die() 
    {
        if (isAlive)
        {
            isAlive = false;
            Animator.enabled = false;
            inputManager.Disable();
            foreach (var body in bodies) 
            { 
                body.isKinematic = false;
                Destroy(CharacterController);
            }
        }
    }

    private void Fight_performed(InputAction.CallbackContext obj)
    {
        if (inputManager.CharacterMap.Run.IsPressed()) { Animator.SetTrigger("FlyingKnee"); }

        else
        {
            Animator.SetTrigger("Fight");
            System.Random random = new System.Random();
            int randomPunch = random.Next(0, punches.Count);
            Animator.SetInteger("Kick", random.Next(0, 8));
        }
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (!isJumping)
        {
            Animator.SetTrigger("Jump");
        }
    }

    private void Move(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, velocityY, direction.y);
        if (prohibitMotion) { moveDirection = new Vector3(0, velocityY, 0); }
        isRunning = inputManager.CharacterMap.Run.IsPressed();
        float currentSpeed = isRunning ? sprintSpeed : moveSpeed;
        if (direction.magnitude > 0.15f)
        {
            if (direction.y < -0.15)
            {
                currentSpeed = moveBackwardsSpeed;
                Animator.SetFloat("Back", direction.y);
            }
            Animator.SetFloat("Back", direction.y);
            targetAnimationSpeed = isRunning ? 1.0f : 0.5f;
        }
        else
        {
            targetAnimationSpeed = 0.0f;
            Animator.SetFloat("Back", direction.y);
        }
        CharacterController.Move(transform.TransformDirection(moveDirection.x * currentSpeed, moveDirection.y, moveDirection.z * currentSpeed)* Time.deltaTime);
        Animator.SetFloat("Speed", Mathf.Lerp(Animator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
    }
    void Rotation()
    {
        if (isAlive && !prohibitRotation)
        {
            yRotation = characterCamera.transform.rotation.eulerAngles.y;
            CharacterController.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
    public void TakeDamage(int damageRate) 
    {
        if (damageRate > health) 
        {
            health = 0;
            Die();
        }
        health -= damageRate;
    }

    void StartKick()
    {
        prohibitMotion = true;
        inputManager.CharacterMap.Fight.Disable();
    }
    void FinishKick()
    {
        prohibitMotion = false;
        inputManager.CharacterMap.Fight.Enable();
    }
    void StopForJump()
    {
        prohibitMotion = true;
        inputManager.CharacterMap.Jump.Disable();
    }
    void StartJump()
    {
        prohibitMotion = false;
        velocityY += jumpHeight;
        isJumping = true;
    }
    void FinishJump()
    {
        Debug.Log("finish Jump");
    }
    void LandingStart() 
    { 
        prohibitMotion = true; 
    }
    void LandingFinish() 
    { 
        prohibitMotion = false;
        inputManager.CharacterMap.Jump.Enable();
    }
    void StartDance() 
    {
        prohibitMotion = true;
        prohibitRotation = true; 
    }
    void FinishDance() 
    {
        prohibitMotion = false;
        prohibitRotation = false; 
    }
}
