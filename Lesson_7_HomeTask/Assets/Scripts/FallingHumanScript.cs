using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingHumanScript : MonoBehaviour
{
    public GameObject human;
    bool exists = false;
    float distance = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (exists) 
        {
            if (Vector3.Distance(transform.position, human.transform.position) > distance & transform.position.y > human.transform.position.y) 
            {
                Debug.Log("inactive falling human");
                human.SetActive(false);
                exists = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        human.SetActive(true);
        exists = true;
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
