using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    Renderer re;
    public Renderer RE { get { return re = re ?? GetComponent<Renderer>(); } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            RE.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
