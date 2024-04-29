using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed = 5f;
    private bool movingToPoint2 = true;
    void Start()
    {
    }
    void Update()
    {
        if (movingToPoint2)
        {
            //https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
            transform.position = Vector3.MoveTowards(transform.position, point2.position, speed * Time.deltaTime);
            if (transform.position == point2.position)
                movingToPoint2 = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
            if (transform.position == point1.position)
                movingToPoint2 = true;
        }
    }
}
