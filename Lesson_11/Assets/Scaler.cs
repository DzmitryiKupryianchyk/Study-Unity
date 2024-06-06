using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private Vector3 targetSize;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.localScale, targetSize) > 0.05f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetSize, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            float randomScale = Random.Range(0.5f, 2.0f);
            targetSize = new Vector3(randomScale, randomScale, randomScale);
        }
    }
}
