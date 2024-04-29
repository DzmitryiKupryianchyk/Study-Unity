using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTwoManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
            textMeshPro.text = "Two is being clicked!";
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
