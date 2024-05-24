using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.GridBrushBase;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float sprintSpeed = 7.0f;
    float yRotation;
    float jumpHeight = 3.0f;
    float gravity = -9.81f;
    bool isRunning;
    bool isJumping = false;
    bool isAlive = true;
    public float animationBlendSpeed = 0.2f;
    float targetAnimationSpeed = 0.0f;
    float velocityY;
    private PlayerInputManager inputManager;
    CharacterController characterController;
    Camera characterCamera;
    Animator animator;
    public CharacterController CharacterController { get { return characterController = characterController ?? GetComponent<CharacterController>(); } }
    public Camera CharacterCamera { get { return characterCamera = characterCamera ?? FindFirstObjectByType<Camera>(); } }
    public Animator Animator { get { return animator = animator ?? GetComponent<Animator>(); } }
    public List <string> punches;
   
    private void OnEnable()
    {
        inputManager = new PlayerInputManager();
        inputManager.EllenMap.Fight.performed += context => Fight();
        inputManager.EllenMap.Dead.performed += context => Dead();
        inputManager.Enable();
    }
    private void OnDisable()
    {
        inputManager.EllenMap.Fight.performed -= context => Fight();
        inputManager.EllenMap.Dead.performed -= context => Dead();
        inputManager.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(MotionDelay());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = inputManager.EllenMap.Move.ReadValue<Vector2>();
        Move(direction);
        Rotation();
        if (inputManager.EllenMap.Jump.IsPressed() & CharacterController.isGrounded)
        {
            isJumping = true;
            Animator.SetTrigger("jump");
            velocityY += jumpHeight;
        }
        if (!CharacterController.isGrounded)
        {
            velocityY += gravity * Time.deltaTime;
        }
        else if (velocityY < 0.0f)
        {
            velocityY = 0.0f;
        }
        Animator.SetFloat("speedY", velocityY / jumpHeight);

        if (isJumping & velocityY < 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f, LayerMask.GetMask("Default")))
            {
                isJumping = false;
                Animator.SetTrigger("land");
            }
        }
    }
    
    void Fight()
    {
        Debug.Log("Fight!");
        Animator.SetTrigger("fight");
        System.Random random = new System.Random();
        int randomPunch = random.Next(0, punches.Count );
        Animator.SetTrigger(punches[randomPunch]);
        StartCoroutine(PunchDelay());
    }
    void Dead() 
    {
        if (isAlive)
        {
            Animator.SetTrigger("death");
            isAlive = false;
            inputManager.Disable();
        }
    }
    void Move(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, velocityY, direction.y);
        Vector3 verticalMovement = Vector3.up * velocityY;
        isRunning = inputManager.EllenMap.Run.IsPressed();
        float currentSpeed = isRunning ? sprintSpeed : moveSpeed;
        if (direction.x != 0 | direction.y != 0)
        {
            targetAnimationSpeed = isRunning ? 1.0f : 0.5f;

        }
        else { targetAnimationSpeed = 0.0f; }

        CharacterController.Move(transform.TransformDirection(verticalMovement + moveDirection) * currentSpeed * Time.deltaTime);
        Animator.SetFloat("speed", Mathf.Lerp(Animator.GetFloat("speed"), targetAnimationSpeed, animationBlendSpeed));
    }
    void Rotation() 
    {
        if (isAlive)
        {
            yRotation = CharacterCamera.transform.rotation.eulerAngles.y;
            CharacterController.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
    IEnumerator MotionDelay() 
    {
        inputManager.EllenMap.Move.Disable();
        yield return new WaitForSeconds(2.0f);
        inputManager.EllenMap.Move.Enable();
    }
    IEnumerator PunchDelay()
    {
        inputManager.EllenMap.Fight.Disable();
        yield return new WaitForSeconds(0.5f);
        inputManager.EllenMap.Fight.Enable();
    }
}
