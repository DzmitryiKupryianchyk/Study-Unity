using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float teleportInterval = 2f;

    private void Start()
    {
        // https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
        // Альтернатива - https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
        InvokeRepeating("TeleportToRandomPosition", 0f, teleportInterval);
    }

    private void TeleportToRandomPosition()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomy = Random.Range(-10f, 10f);
        float randomZ = Random.Range(-10f, 10f);

        transform.position = new Vector3(randomX, randomy, randomZ);
    }
}
