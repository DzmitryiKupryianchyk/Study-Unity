using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForLamp : MonoBehaviour
{
    public Light light;
    public AudioSource audioSource;
    public float lightFrequency = 0.25f;
    float timerDown;
    bool blink = false;
    int iteration = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blink) 
        {
            BlinkLight();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            blink = true;
            audioSource.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    void BlinkLight()
    {
        if (timerDown >= 0)
        {
            timerDown -= Time.deltaTime;
        }
        if (timerDown < 0)
        {
            if (light.enabled & iteration < 23)
            {
                light.enabled = false;
                iteration++;
                timerDown = lightFrequency;
            }
            else if (iteration < 23) 
            { 
                light.enabled = true; 
                iteration++;
                timerDown = lightFrequency;
            }
        }
        if (iteration == 23) 
        { 
            blink = false;
            iteration = 0;
        }
    }
}
