using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstackleMovement : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 finishPoint;
    public float speed;
    private bool movingToPoint2 = true;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (movingToPoint2)
        {
            transform.position = Vector3.MoveTowards(transform.position, finishPoint, speed * Time.deltaTime);
            if (transform.position == finishPoint)
                movingToPoint2 = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, speed * Time.deltaTime);
            if (transform.position == startPoint)
                movingToPoint2 = true;
        }
    }
}
