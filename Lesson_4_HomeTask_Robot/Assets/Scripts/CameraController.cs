using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    //public Transform turretBody;
    public Transform flag;
    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -25f, 50f);

        yRotation -= mouseX;
        //yRotation = Mathf.Clamp(-90f, yRotation, 90f);

        transform.localRotation = Quaternion.Euler(-xRotation, -yRotation, 0f);
        //turretBody.Rotate(Vector3.up * mouseX);
    }
}

    

