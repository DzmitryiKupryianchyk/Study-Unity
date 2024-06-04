using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 3.0f;
    [SerializeField]private Transform player;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = new Vector3(player.position.x, player.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, position, cameraSpeed * Time.deltaTime);
    }
}
