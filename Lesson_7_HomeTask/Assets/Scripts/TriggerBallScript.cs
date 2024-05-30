using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBallScript : MonoBehaviour
{
    public Light light;
    public AudioSource lamp;
    public AudioSource girlLaugh;
    public GameObject ball;
    public float lightFrequency = 0.1f;
    float timerDown;
    bool blink = false;
    int iteration = 0;
    public int finishBlinks = 131;
    public int destroyBall = 231;
    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);
        light.enabled = false;
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
            lamp.Play();
            blink = true;
            StartCoroutine(GirlLaughDelay());
            ball.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {

    }
    IEnumerator GirlLaughDelay() 
    {
        yield return new WaitForSeconds(3);
        girlLaugh.Play();
    }
    void BlinkLight()
    {
        if (timerDown >= 0)
        {
            timerDown -= Time.deltaTime;
        }
        if (timerDown < 0)
        {
            if (!light.enabled & iteration < finishBlinks)
            {
                light.enabled = true;
                iteration++;
                timerDown = lightFrequency;
            }
            else if (iteration < finishBlinks)
            {
                light.enabled = false;
                iteration++;
                timerDown = lightFrequency;
            }
            else if (iteration < destroyBall)
            {
                iteration++;
            }
            else
            {
                blink = false;
                iteration = 0;
                ball.SetActive(false);
            }
        }
    }
}
