using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellLogic : MonoBehaviour
{
    public ParticleSystem explosion;
    public ParticleSystem ShellCollision;
    Rigidbody rb;
    public int index;
    public bool isExplosive = false;
    public float explosionForce = 1500f;
    public float explosionRadius = 150.0f;
    Vector3 firstPosition;
    float maxDistance = 1600.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firstPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 0)
        {
            isExplosive = false;
            rb.mass = 0.1f;
            rb.drag = 1f;
            rb.angularDrag = 0.1f;
            GetComponent<Renderer>().material.color = Color.white;
        }
        if (index == 1)
        {
            isExplosive = false;
            rb.mass = 0.4f;
            rb.drag = 0.1f;
            GetComponent<Renderer>().material.color = Color.red;
        }
        if (index == 2)
        {
            isExplosive = true;
            rb.mass = 0.6f;
            rb.drag = 0.1f;
            GetComponent<Renderer>().material.color = Color.yellow;

        }
        if (index == 3)
        {
            isExplosive = false;
            rb.mass = 0.05f;
            rb.drag = 0.025f;
            GetComponent<Renderer>().material.color = Color.green;
        }
        DestroyAnyway();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isExplosive)
        {
            Vector3 explosionPosition = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb1 = hit.GetComponent<Rigidbody>();
                if (rb1 != null)
                {
                    rb1.AddExplosionForce(explosionForce *100, explosionPosition, explosionRadius * 10000 );
                }
            }
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (index == 1) { Instantiate(ShellCollision, transform.position, Quaternion.identity);  }
    }
    private void OnCollisionStay(Collision collision)
    {
        StartCoroutine(DestroyShellDelayed(gameObject));
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
    IEnumerator DestroyShellDelayed(GameObject shell)
    {
        yield return new WaitForSeconds(5);
        Destroy(shell);
    }
    private void DestroyAnyway()
    {
        if (gameObject != null && Vector3.Distance(firstPosition, gameObject.transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
