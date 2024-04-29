using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputButton : MonoBehaviour, IPointerDownHandler
{
    public Image inputMenu;
    public TMP_InputField inputField;
    public Button getBack;
    public void OnPointerDown(PointerEventData eventData)
    {
        inputMenu.gameObject.SetActive(true);
        inputField.gameObject.SetActive(true);
        getBack.gameObject.SetActive(true);
    }
}
