using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NinjaMotion : MonoBehaviour
{
    public bool turnedRight = true;
    public bool isMoving;
    private NinjaController controller;
    CharacterController characterController;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public CharacterController CharacterController { get { return characterController = characterController ?? GetComponent<CharacterController>(); } }
    public Animator Animator { get { return animator = animator ?? GetComponent<Animator>(); } }
    public SpriteRenderer SpriteRenderer { get { return spriteRenderer = spriteRenderer ?? GetComponent<SpriteRenderer>(); } }
    private void OnEnable()
    {
        controller = new NinjaController();
        controller.Enable();
    }
    private void OnDisable()
    {
        controller.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = controller.NinjaMap.Movement.ReadValue<Vector2>();
        if (direction.x > 0) 
        { 
            turnedRight = true;
            isMoving = true;
            SpriteRenderer.flipX = false;
            Animator.SetTrigger("Run");
        }
        if (direction.x < 0) 
        {
            turnedRight = false;
            isMoving = true;
            SpriteRenderer.flipX = true;
            Animator.SetTrigger("Run");
        }
        if (direction.x == 0) 
        { 
            isMoving = false;
            Animator.SetTrigger("Idle");
        }

    }
}
