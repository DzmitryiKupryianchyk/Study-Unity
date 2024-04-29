using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private Vector3 smallSize;
    public Vector3 bigSize;
    public float speed;
    private bool isGrowing = true;

    void Start()
    {
        smallSize = transform.localScale;
    }

    void Update()
    {
        if (isGrowing)
        {
            // https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
            transform.localScale = Vector3.Lerp(transform.localScale, bigSize, speed * Time.deltaTime);

            // https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
            if (Vector3.Distance(transform.localScale, bigSize) < 0.05f)
            {
                isGrowing = false;
            }
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, smallSize, speed * Time.deltaTime);

            if (Vector3.Distance(transform.localScale, smallSize) < 0.05f)
            {
                isGrowing = true;
            }
        }
    }
}
