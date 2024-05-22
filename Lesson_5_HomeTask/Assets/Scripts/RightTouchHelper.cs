using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightTouchHelper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler
{
    public CharacterControl character;
    private bool isDragging;
    float sensitivity = 15.0f;
    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                Debug.Log("Rotate");
                Vector2 delta = eventData.delta;
                float rotationY = (delta.x * sensitivity * 5 * Time.deltaTime);
                float rotationX = (delta.y * sensitivity * Time.deltaTime);
                character.Camera(rotationX);
                character.Rotation(rotationY);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
