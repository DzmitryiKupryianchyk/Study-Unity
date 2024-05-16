using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    Vector3 rotationDirection = Vector3.up;
    float rotationSpeed = 30.0f;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 0) 
        { 
        }
        if (index == 1)
        {
            transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
        }
        if (index == 2) 
        {
            transform.Rotate(-rotationDirection * rotationSpeed * Time.deltaTime);
        }
    }
}
