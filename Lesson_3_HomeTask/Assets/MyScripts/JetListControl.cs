using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JetListControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler
{
    public GameObject[] jets;
    private GameObject currentJet;
    private int currentJetIndex;
    private Color[] colors;
    float rotateSpeed = 30.0f;
    //private Vector2 startPosition;
    private bool isDragging;
    public GameObject spotForMiniCamera;
    
    void Start()
    {
        colors = new Color[jets.Length];
        currentJetIndex = 0;
        currentJet = Instantiate(jets[currentJetIndex]);
        currentJet.GetComponent<Renderer>().material.color = Color.gray;
        for (int i = 0; i < colors.Length; i++) 
        {
            colors[i] = currentJet.GetComponent<Renderer>().material.color;
        }
    }

    public void ChangeJetOnButtonLeft() 
    {
        Destroy(currentJet);
        if (currentJetIndex > 0) 
        { 
            currentJetIndex--;
            currentJet = Instantiate(jets[currentJetIndex]);
            currentJet.GetComponent<Renderer>().material.color = colors[currentJetIndex];
        }
        else 
        {
            currentJetIndex = jets.Length - 1;
            currentJet = Instantiate(jets[currentJetIndex]);
            currentJet.GetComponent<Renderer>().material.color = colors[currentJetIndex];
        }
    }

    public void ChangeJetOnButtonRight()
    {
        Destroy(currentJet);
        if (currentJetIndex < jets.Length - 1)
        {
            currentJetIndex++;
            currentJet = Instantiate(jets[currentJetIndex]);
            currentJet.GetComponent<Renderer>().material.color = colors[currentJetIndex];
        }
        else
        {
            currentJetIndex = 0;
            currentJet = Instantiate(jets[currentJetIndex]);
            currentJet.GetComponent<Renderer>().material.color = colors[currentJetIndex];
        }
        spotForMiniCamera.transform.rotation = Quaternion.identity;
    }

    public void ChangeColorOfCurrentJet(int index)
    {
        switch (index)
        { 
            case 0:
                currentJet.GetComponent<Renderer>().material.color = Color.red;
                colors[currentJetIndex] = currentJet.GetComponent<Renderer>().material.color;
                break;
            case 1:
                currentJet.GetComponent<Renderer>().material.color = Color.blue;
                colors[currentJetIndex] = currentJet.GetComponent<Renderer>().material.color;
                break;
            case 2:
                currentJet.GetComponent<Renderer>().material.color = Color.yellow;
                colors[currentJetIndex] = currentJet.GetComponent<Renderer>().material.color;
                break;
            case 3:
                currentJet.GetComponent<Renderer>().material.color = Color.green;
                colors[currentJetIndex] = currentJet.GetComponent<Renderer>().material.color;
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //startPosition = eventData.position;
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                Vector2 delta = eventData.delta;
                float rotationY = (delta.x * rotateSpeed * Time.deltaTime);
                //Quaternion deltaRotation = Quaternion.Euler(0, rotationY, 0);
                currentJet.transform.rotation *= Quaternion.Euler(0, - rotationY, 0);
                spotForMiniCamera.transform.rotation *= Quaternion.Euler(0, -rotationY, 0);
                //startPosition = eventData.position;
            }
        }
    }
    private void Update()
    {
    }
}
