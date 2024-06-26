using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class RobotController : MonoBehaviour
{
    public ParticleSystem exaust;
    public ParticleSystem shotFire;
    public float speed = 100.0f;
    public float rotationSpeed = 100.0f;
    private Rigidbody rb;
    public GameObject originalShell;
    public Collider ordinaryShellsStend;
    public Collider bombShellsStend;
    public Collider ballShellsStend;
    GameObject currentShell;
    Rigidbody shell;
    public Transform aim;
    public float shootForce = 20f;
    public GameObject clip;
    public float torque = 1000.0f;
    public ShellLogic shellLogic;
    float shootingFrequency = 2.0f;
    private float fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(exaust, exaust.transform.position, Quaternion.identity);
        Instantiate(shotFire, shotFire.transform.position, Quaternion.identity);
        rb = GetComponent<Rigidbody>();
        originalShell.GetComponent<ShellLogic>().index = 0;
        shootForce = 8.0f;
    }
    
    // Update is called once per frame
    void Update()
    {
    }
    
    void FixedUpdate()
    {
        Shoot();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(-transform.forward * 10 * speed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            float turn = Input.GetAxis("Horizontal");
            
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) rb.AddTorque(transform.up * torque * -turn);
            else rb.AddTorque(transform.up * torque * turn);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(transform.forward * 10 * speed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            float turn = Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) rb.AddTorque(transform.up * torque * -turn);
            else rb.AddTorque(transform.up * torque * turn);
        }
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if (other == ordinaryShellsStend) 
        {
            originalShell.GetComponent<ShellLogic>().index = 1;
            shootForce = 60.0f;
        }
        if (other == bombShellsStend)
        {
            originalShell.GetComponent<ShellLogic>().index = 2;
            shootForce = 20.0f;
        }
        if (other == ballShellsStend)
        {
            originalShell.GetComponent<ShellLogic>().index = 3;
            shootForce = 10f;
        }
    }
    void OnTriggerStay(Collider other) 
    {
        if (other == ordinaryShellsStend)
        {
            
        }
        if (other == bombShellsStend)
        {
           
        }
        if (other == ballShellsStend)
        {
            
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        originalShell.GetComponent<ShellLogic>().index = 0;
        shootForce = 8.0f;
        Destroy(currentShell);
    }
    
    private void Shoot() 
    {
        if (Input.GetKey(KeyCode.Mouse0))
        { 
            if (Time.time > fireTimer)
            {
                exaust.Play();
                shotFire.Play();
                currentShell = Instantiate(originalShell, clip.transform.position, clip.transform.rotation);
                shell = currentShell.GetComponent<Rigidbody>();
                Vector3 direction = (aim.position - clip.transform.position).normalized;
                shell.AddForce(direction * shootForce, ForceMode.Impulse);
                fireTimer = Time.time + 1f / shootingFrequency;
            }
        }
    }
}
