using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class MannequinTriggerScript : MonoBehaviour
{
    public GameObject mannequin;
    public Light light;
    public AudioSource playerAudioSource;
    public AudioClip breathing;
    public AudioClip heartBeating;
    public AudioClip scream;
    public AudioClip flashLight;
    float turnOffDelay = 3.0f;
    float turnOnDelay = 2.0f;
    bool screamer;
    int iteration = 0;
    float timerDown;
    // Start is called before the first frame update
    void Start()
    {
        timerDown = turnOnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (screamer) 
        {
            StartScreamer();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAudioSource.PlayOneShot(flashLight);
            light.enabled = false;
            mannequin.SetActive(true);
            screamer = true;
            //StartCoroutine(Delay());
        }
    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {

    }

    void StartScreamer() 
    {
        if (timerDown >= 0)
        {
            timerDown -= Time.deltaTime;
        }
        if (timerDown < 0)
        {
            if (iteration == 0)
            {
                playerAudioSource.PlayOneShot(flashLight);
                light.enabled = true;
                timerDown = turnOffDelay;
                iteration++;
                
            }
            else if (iteration == 1)
            {
                playerAudioSource.PlayOneShot(flashLight);
                light.enabled = false;
                mannequin.SetActive(false);
                playerAudioSource.PlayOneShot(breathing);
                playerAudioSource.PlayOneShot(heartBeating);
                iteration++;
                timerDown = turnOnDelay * 2;
            }
            else if (iteration == 2) 
            {
                playerAudioSource.PlayOneShot(scream);
                timerDown = turnOnDelay * 2;
                iteration++;
            }
            else if (iteration == 3)
            {
                playerAudioSource.PlayOneShot(flashLight);
                light.enabled = true;
                timerDown = turnOnDelay * 2;
                iteration = 0;
                screamer = false;
            }
        }
    }
}
