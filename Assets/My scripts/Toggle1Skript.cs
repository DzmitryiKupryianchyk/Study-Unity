using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Toggle1Skript : MonoBehaviour, IPointerClickHandler
{
    public Toggle toggle;
    public Toggle toggle2;
    public Toggle toggle3;
    public TMP_Text thisText;
    public TMP_Text menuText;

    public void OnPointerClick(PointerEventData eventData)
    {
        toggle.isOn = true;
        toggle2.isOn = false;
        toggle3.isOn = false;
        menuText.text = thisText.text;
    }
}
