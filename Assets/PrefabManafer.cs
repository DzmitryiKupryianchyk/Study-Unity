using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject[] prefabs;
    GameObject currentPrefab;

    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentPrefab != null)
            {
                Destroy(currentPrefab);
            }
            GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            // https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
            currentPrefab = Instantiate(randomPrefab, transform.position, Quaternion.identity);
        }
    }
}
