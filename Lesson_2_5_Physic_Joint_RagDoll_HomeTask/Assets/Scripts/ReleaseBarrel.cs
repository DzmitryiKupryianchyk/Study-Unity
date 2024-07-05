using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseBarrel : MonoBehaviour
{
    public Rigidbody barrel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            barrel.isKinematic = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
    }
}
