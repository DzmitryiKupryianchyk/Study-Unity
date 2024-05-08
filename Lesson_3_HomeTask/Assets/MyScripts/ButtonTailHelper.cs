using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTailHelper : MonoBehaviour, IPointerClickHandler
{
    public Camera camera;
    public Transform parentObject;
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 localPosition = new Vector3(0.0f, 0.0f, 1726.0f);
        Vector3 globalPosition = parentObject.TransformPoint(localPosition);

        camera.transform.position = globalPosition;

        Vector3 localRotation = new Vector3(0.0f, 180.0f, 0f);
        Quaternion globalRotation = Quaternion.Euler(localRotation);

        camera.transform.rotation = parentObject.rotation * globalRotation;
    }
}
