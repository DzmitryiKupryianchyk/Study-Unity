using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMover : MonoBehaviour
{
    private float gravity = -9.81f;
    public float moveSpeed = 1.4f;
    public float stepSoundFrequency = 0.9f;
    float timerDown;
    private float sensitivity = 10.0f;
    private bool isGrounded;
    float currentXRotation = 0f;
    private Vector3 velocity;
    private PlayerInput inputManager;
    CharacterController characterController;
    AudioSource audio;
    AudioClip clip;
    public GameObject spotForCamera;
    public GameObject spotForLight;
    public Light spotlight;

    public CharacterController CharacterController { get { return characterController = characterController ?? GetComponent<CharacterController>(); } }
    public AudioSource Audio { get { return audio = audio ?? GetComponent<AudioSource>(); } }
    public AudioClip Clip { get { return clip = clip ?? GetComponent<AudioClip>(); } }
    private void OnEnable()
    {
        inputManager = new PlayerInput();
        inputManager.Enable();
    }
    private void OnDisable()
    {
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
        isGrounded = CharacterController.isGrounded;
        Vector2 direction = inputManager.Player.Move.ReadValue<Vector2>();
        Vector2 rotation = inputManager.Player.Rotation.ReadValue<Vector2>();
        Motion(direction);
        Turn(rotation);
        if (direction.x != 0 || direction.y !=0) 
        {
            PlaySteps();
        }
    }
    void Motion(Vector2 direction) 
    {
        if (isGrounded & velocity.y < 0)
        {
            velocity.y = 0.0f;
        }
        velocity.y += gravity * Time.deltaTime;
        Vector3 moveDirection = transform.TransformDirection( new Vector3(direction.x, - velocity.y, direction.y));
        CharacterController.Move( - moveDirection * moveSpeed * Time.deltaTime);
    }
    void Turn(Vector2 rotation) 
    {
        
        float xRotation = rotation.y * sensitivity * Time.deltaTime;
        float yRotation = rotation.x * sensitivity * Time.deltaTime;

        currentXRotation += xRotation;
        currentXRotation = Mathf.Clamp(currentXRotation, -25f, 50f);

        CharacterController.transform.rotation *= Quaternion.Euler(0, yRotation, 0);
        spotForCamera.transform.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
        spotForLight.transform.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
    }
    void PlaySteps () 
    {
        if(timerDown >= 0)
        { 
            timerDown-= Time.deltaTime; 
        }
        if (timerDown < 0)
        {
            Audio.Play();
            timerDown = stepSoundFrequency;
        }
    }
}
