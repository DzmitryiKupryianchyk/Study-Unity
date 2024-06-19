using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animator;


    public Animator Animator { get { return animator = animator ?? GetComponent<Animator>(); } }
    public SpriteRenderer SpriteRenderer { get { return sprite = sprite ?? GetComponent<SpriteRenderer>(); } }
    public Rigidbody2D RB { get { return rb = rb ?? GetComponent<Rigidbody2D>(); } }

    CharacterInputControl inputControl;

    private void OnEnable()
    {
        inputControl = new CharacterInputControl();
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputDirection = inputControl.CharacterMap.Motion.ReadValue<Vector2>();
        
        //RB.velocity = direction * speed;
        Move(inputDirection);
    }
    void Move(Vector2 inputDirection)
    {
        Vector2 moveDirection = new Vector2(inputDirection.x - inputDirection.y, (inputDirection.x + inputDirection.y)/2);
        //moveDirection = Vector3.ClampMagnitude(moveDirection, speed);
        RB.transform.position = Vector3.MoveTowards(RB.transform.position, RB.position + moveDirection, speed * Time.deltaTime);
        Debug.Log($"x = {inputDirection.x}, y = {inputDirection.y}");
        SetAnimation(inputDirection);
    }
    void SetAnimation(Vector2 inputDirection)
    { 
        if (inputDirection.magnitude > 0.1) 
        {
            //Animator.SetBool("Idle", false);
            Animator.SetFloat("H", inputDirection.x);
            Animator.SetFloat("V", inputDirection.y);

        }
        else
        {
            Animator.SetFloat("H", 0);
            Animator.SetFloat("V", 0);
            //Animator.SetBool("Idle", true);
            Animator.SetTrigger("Stop");
        }

            
    }

}
