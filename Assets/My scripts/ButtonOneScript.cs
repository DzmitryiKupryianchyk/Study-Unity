using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonOneScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI textMeshPro;
    private string originalText;
    public Button button;

    void Start()
    {
        originalText = textMeshPro.text;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (button.interactable)
        {
            textMeshPro.text = "One is being clicked!";
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (button.interactable)
        {
            textMeshPro.text = originalText;
        }
    }
}
