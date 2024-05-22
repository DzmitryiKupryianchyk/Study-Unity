using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
[RequireComponent(typeof(CharacterController))]
public class CharacterControl : MonoBehaviour
{
    public float gravity = - 9.81f;
    CharacterController controller;
    public float speed = 1.6f;
    float xRotation = 0f;
    float yRotation = 0f;
    public GameObject pointForCamera;
    float jumpHeight = 1.5f;
    private Vector3 velocity;
    bool move = false;
    private bool isGrounded;
    Animator animator;
    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }
    public Animator Animator { get { return animator = animator ?? GetComponent<Animator>(); } }
    
    private void Start()
    {
        //UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        pointForCamera = GameObject.Find("PointForCamera");
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(isGrounded);
        if (!move)
        {
            Vector3 gravityV = new Vector3(0, gravity, 0);
            Controller.Move(velocity * Time.deltaTime);
        }
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y == 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        
        if (!isGrounded) 
        {
            Animator.SetBool("isFlying", true);
        }
        else Animator.SetBool("isFlying", false);
    }
    public void Motion(float vertical, float horizontal) 
    {
        move = true;
        vertical = Mathf.Clamp(vertical, -0.8f, 1.6f);
        horizontal = Mathf.Clamp(horizontal, -0.8f, 0.8f);
        
        Vector3 movement = new Vector3(horizontal * speed, velocity.y, vertical * speed);
        Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        move = false;
    }
    public void Camera(float mouseY) 
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -25f, 50f);
        pointForCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    public void Rotation(float mouseX) 
    {
        yRotation = - mouseX;
        Controller.transform.rotation *= Quaternion.Euler(0, -yRotation, 0);
    }
    
    public void Jump()
    {
        if (isGrounded)
        {
            //Animator.SetBool("isJumping", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
