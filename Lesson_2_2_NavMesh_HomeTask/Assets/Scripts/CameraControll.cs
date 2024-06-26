using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform character;
    private float distanceX = 17.0f;
    private float distanceY = 48.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(character.position.x + distanceX, character.position.y + distanceY, character.position.z);
    }
}
