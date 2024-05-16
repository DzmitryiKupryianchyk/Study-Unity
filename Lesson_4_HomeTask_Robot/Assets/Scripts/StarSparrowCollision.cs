using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSparrowCollision : MonoBehaviour
{
    public float speed = 5.0f;
    public float radius = 75f;
    Vector3 center;
    Rigidbody rb;
    private float angle = 0f;
    public GameObject shell;
    public GameObject spot;
    public int index;
    public int traectory;
    public Collider penetration;
    bool isPenetrated = false;
    void Start()
    {
        if (index == 0)
        {
            angle = 0;
        }
        if (index == 1)
        {
            angle = -90;
        }
        if (index == 2)
        {
            angle = 90;
        }
        if (index == 3)
        {
            angle = 180;
        }
        spot = GameObject.Find("Point");
        center = spot.transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!isPenetrated) 
        {
            fly();
        }
    }
    void fly()
    {
        if (traectory == 0)
        {
            angle += speed * Time.deltaTime;
            float x = center.x + radius * Mathf.Sin(angle);
            float z = center.z + radius * Mathf.Sin(angle);
            Vector3 newPosition = new Vector3(x, transform.position.y, z);
            rb.velocity = newPosition - transform.position;
            Vector3 direction = (newPosition + transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(-direction);
            Vector3 forceDirection = (newPosition - transform.position).normalized;
            rb.AddForce(forceDirection * speed, ForceMode.Force);
            rb.MoveRotation(lookRotation);
            
        }
        if (traectory == 1)
        {
            angle += speed * Time.deltaTime;
            float x = center.x + radius * Mathf.Cos(angle);
            float z = center.z + radius * Mathf.Cos(angle);
            Vector3 newPosition = new Vector3(x, transform.position.y, z);
            rb.velocity = newPosition - transform.position;
            Vector3 direction = (newPosition + transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(-direction);
            Vector3 forceDirection = (newPosition - transform.position).normalized;
            rb.AddForce(forceDirection * speed, ForceMode.Force);
            rb.MoveRotation(lookRotation);
        }
        if (traectory == 2)
        {
            angle += speed * Time.deltaTime;
            float x = center.x + radius * Mathf.Sin(angle);
            float z = center.z + radius * Mathf.Cos(angle);
            Vector3 newPosition = new Vector3(x, transform.position.y, z);
            rb.velocity = newPosition - transform.position;
            Vector3 forceDirection = (newPosition - transform.position).normalized;
            Vector3 movementDirection = rb.velocity.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);

            rb.AddForce(forceDirection * speed, ForceMode.Force);
            rb.MoveRotation(targetRotation);
        }
        if (traectory == 3)
        {
            angle += speed * Time.deltaTime;
            float x = center.x + radius * Mathf.Cos(angle);
            float z = center.z + radius * Mathf.Sin(angle);
            Vector3 newPosition = new Vector3(x, transform.position.y, z);
            rb.velocity = newPosition - transform.position;
            Vector3 direction = (newPosition + transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(-direction);
            Vector3 forceDirection = (newPosition - transform.position).normalized;
            rb.AddForce(forceDirection * speed, ForceMode.Force);
            rb.MoveRotation(lookRotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        isPenetrated = true;
    }
}
