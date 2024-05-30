using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    AudioSource audio;
    public AudioSource spookyVoice;
    
    public AudioSource Audio { get { return audio = audio ?? GetComponent<AudioSource>(); } }
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        Audio.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spookyVoice.Play();
        }
    }
    private void OnTriggerStay(Collider other) 
    { 
    }
}
