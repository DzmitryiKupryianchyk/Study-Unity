using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationDirection = Vector3.up;
    public float rotationSpeed = 50.0f;
    void Start()
    {
    }
    void Update()
    {
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }
}
