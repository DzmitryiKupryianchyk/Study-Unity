using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftTouchHelper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CharacterControl character;
    public CharacterAnimation characterAnimation;
    Vector2 startMousePosition;
    bool isActive;
    float v = 0.0f;
    float h = 0.0f;
    float rotationY;
    float rotationX;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isActive = true;
        startMousePosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isActive = false;
        characterAnimation.v = 0;
        characterAnimation.h = 0;
    }

   

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive)
        {
            
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                Debug.Log("run!");
                Vector2 currentMousePosition = Input.mousePosition;
                Vector2 delta = currentMousePosition - startMousePosition;
                float rotationY = (delta.x * Time.deltaTime);
                float rotationX = (delta.y * Time.deltaTime);
                if (rotationY < delta.x)
                {
                    h = 1;
                }
                else if (rotationY > delta.x)
                {
                    h = -1;
                }
                if (rotationX < delta.y)
                {
                    v = 1;
                }
                else if (rotationX > delta.y)
                {
                    v = -1;
                }
                character.Motion(rotationX, rotationY);
                characterAnimation.v = v;
                characterAnimation.h = h;
            }
        }
    }
}
