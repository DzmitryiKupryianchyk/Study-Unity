using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NewBehaviourScript : MonoBehaviour
{
    public Mesh[] meshes;
    protected Mesh currMesh;
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
            ChangeMesh();
        }
    }
   
    void ChangeMesh()
    {
        Mesh newMesh = meshes[Random.Range(0, meshes.Length)];
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();

        if (meshFilter != null)
        {
            meshFilter.mesh = newMesh;
        }
        else
        {
            Debug.LogError("MeshFilter not found!");
        }
    }
}
