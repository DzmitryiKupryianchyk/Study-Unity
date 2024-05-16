using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attempt : MonoBehaviour
{
    
    public float speed = 0.5f;
    public float radius = 75f;
    Vector3 center;
    Rigidbody rb;
    private float angle = 0f;
    Vector3 currentVelocity;
    public GameObject shell;
    public GameObject spot;
    public int index;
    public int traectory;
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
        currentVelocity = rb.velocity;
    }

    void FixedUpdate()
    {
        fly();
    }
    void fly() 
    {
        if (traectory == 0) 
        {
            angle += speed * Time.deltaTime;
            float x = center.x + radius * Mathf.Sin(angle);
            float z = center.z + radius * Mathf.Sin(angle);
            Vector3 newPosition = new Vector3(x, transform.position.y, z);
            transform.position = newPosition;
            Vector3 direction = (newPosition + transform.position);//.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(-direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
        if (traectory == 1)
        {
            angle += speed * Time.deltaTime;
            float x = center.x + radius * Mathf.Cos(angle);
            float z = center.z + radius * Mathf.Cos(angle);
            Vector3 newPosition = new Vector3(x, transform.position.y, z);
            transform.position = newPosition;
            Vector3 direction = (newPosition + transform.position);//.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(-direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
        if (traectory == 2)
        {
            angle += speed * Time.deltaTime;
            float x = center.x + radius * Mathf.Sin(angle);
            float z = center.z + radius * Mathf.Cos(angle);
            Vector3 newPosition = new Vector3(x, transform.position.y, z);
            transform.position = newPosition;
            Vector3 direction = (newPosition + transform.position);//.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(-direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
        if (traectory == 3)
        {
            angle += speed * Time.deltaTime;
            float x = center.x + radius * Mathf.Cos(angle);
            float z = center.z + radius * Mathf.Sin(angle);
            Vector3 newPosition = new Vector3(x, transform.position.y, z);
            transform.position = newPosition;
            Vector3 direction = (newPosition + transform.position);//.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(-direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        //rb.velocity = Quaternion.Lerp(currentVelocity, Vector3.zero, 7 * Time.deltaTime);
        rb.velocity = Vector3.zero;
        //StartCoroutine(DetatchFromParent(gameObject));
    }
    IEnumerator DetatchFromParent(GameObject jet)
    {
        yield return new WaitForSeconds(5);
        if (jet.transform.parent != null)
        {
            jet.transform.parent = null;
        }
    }

}
