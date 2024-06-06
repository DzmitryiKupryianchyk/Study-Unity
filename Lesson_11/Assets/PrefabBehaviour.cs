using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class PrefabBehaviour : MonoBehaviour
{
    [SerializeField]private float speed;
    Rigidbody rb;
    Renderer re;
    public Rigidbody RB { get { return rb = rb ?? GetComponent<Rigidbody>(); } }
    public Renderer RE { get { return re = re ?? GetComponent<Renderer>(); } }

    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        Vector3 direction = new Vector3(randomX, 0f, randomZ);
        RB.AddForce(direction * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
