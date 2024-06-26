using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DoorsControl : MonoBehaviour
{
    private bool isOpen = false;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
        targetRotation = startRotation * Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, startRotation, 5 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered trigger");
        if (other.gameObject.CompareTag("Player"))
        {
            isOpen = true;
            Debug.Log("Player entered trigger");
        }
    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpen = false;
            Debug.Log("Player left trigger");
        }
        Debug.Log("something left trigger");
    }
}
