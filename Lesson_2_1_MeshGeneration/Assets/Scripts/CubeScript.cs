using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class CubeScript : MonoBehaviour
{
    public Mesh mesh;
    Renderer re;
    public Renderer RE { get { return re = re ?? GetComponent<Renderer>(); } }

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        mesh.name = "GeneratedMesh";
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = GenerateVerticles();
        mesh.triangles = GenerateTriangles();
        RE.material.color = new Color(Random.value, Random.value, Random.value);
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3[] GenerateVerticles() 
    {
        return new Vector3[]
        {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(0.0f, 0.0f, 10.0f),
            new Vector3(10.0f, 0.0f, 0.0f),
            new Vector3(10.0f, 0.0f, 10.0f),

            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 10.0f),
            new Vector3(10.0f, 1.0f, 0.0f),
            new Vector3(10.0f, 1.0f, 10.0f)
        };
    }

    int[] GenerateTriangles() 
    {
        return new int[] 
        {
            1,0,2,
            1,2,3,

            4,5,6,
            5,7,6,

            0,4,2,
            2,4,6,

            2,6,3,
            3,6,7,

            3,7,1,
            1,7,5,

            1,5,0,
            0,5,4
        };
    }
}
