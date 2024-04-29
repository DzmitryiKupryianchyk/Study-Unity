using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed = 5f;
    private bool movingToPoint2 = true;

    public Vector3 rotationDirection = Vector3.up;
    public float rotationSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);

        if (movingToPoint2)
        {
            transform.position = Vector3.MoveTowards(transform.position, point2.position, speed * Time.deltaTime);
            if (transform.position == point2.position)
                movingToPoint2 = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
            if (transform.position == point1.position)
                movingToPoint2 = true;
        }
    }
}
