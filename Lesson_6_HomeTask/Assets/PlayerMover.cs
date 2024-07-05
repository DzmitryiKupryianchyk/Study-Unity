using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using static UnityEngine.GridBrushBase;

public class PlayerMover : MonoBehaviour
{
    public GameObject cutScene;

    public float moveSpeed = 2.0f;
    public float sprintSpeed = 7.0f;
    float yRotation;
    float jumpHeight = 5.0f;
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
        inputManager.EllenMap.Fight.performed += Fight_performed;
        inputManager.EllenMap.Jump.performed += Jump_performed;
        inputManager.EllenMap.Dead.performed += Dead_performed;
        inputManager.Enable();
    }

    private void OnDisable()
    {
        inputManager.EllenMap.Fight.performed -= Fight_performed;
        inputManager.EllenMap.Jump.performed -= Jump_performed;
        inputManager.EllenMap.Dead.performed -= Dead_performed;
        inputManager.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        cutScene.SetActive(false);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(MotionDelay());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CharacterController.isGrounded);
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
    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (CharacterController.isGrounded)
        {
            isJumping = true;
            Animator.SetTrigger("jump");
            velocityY += jumpHeight;
        }
    }

    private void Dead_performed(InputAction.CallbackContext obj)
    {
        if (isAlive)
        {
            Animator.SetTrigger("death");
            cutScene.SetActive(true);
            isAlive = false;
            inputManager.Disable();
        }
    }

    private void Fight_performed(InputAction.CallbackContext obj)
    {

        Debug.Log("Fight!");
        Animator.SetTrigger("fight");
        System.Random random = new System.Random();
        int randomPunch = random.Next(0, punches.Count);
        Animator.SetTrigger(punches[randomPunch]);
        StartCoroutine(PunchDelay());
    }
    void Move(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, velocityY, direction.y);
        isRunning = inputManager.EllenMap.Run.IsPressed();
        float currentSpeed = isRunning ? sprintSpeed : moveSpeed;
        if (direction.magnitude > 0.1f)
        {
            targetAnimationSpeed = isRunning ? 1.0f : 0.5f;

        }
        else { targetAnimationSpeed = 0.0f; }

        CharacterController.Move(transform.TransformDirection( moveDirection) * currentSpeed * Time.deltaTime);
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
