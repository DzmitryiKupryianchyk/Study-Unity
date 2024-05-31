using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayersShift : MonoBehaviour
{
    float width = 9.28f;
    float maxXShift = 15.0f;
    float shiftSpeed = 3;
    [SerializeField] private float layerAdjustmentSpeed;
    public List<Transform> layers;
    public NinjaMotion ninja;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var layer in layers)
        {
            if (ninja.turnedRight & ninja.isMoving)
            {
                layer.localPosition += shiftSpeed * Time.deltaTime * layerAdjustmentSpeed * Vector3.left;
                if (layer.localPosition.x <= -maxXShift)
                {
                    layer.localPosition += Vector3.right * width * 3;
                }
            }
            if (!ninja.turnedRight & ninja.isMoving)
            {
                layer.localPosition += shiftSpeed * Time.deltaTime * layerAdjustmentSpeed * Vector3.right;
                if (layer.localPosition.x >= maxXShift)
                {
                    layer.localPosition += Vector3.left * width * 3;
                }
            }
        }
    }
}
