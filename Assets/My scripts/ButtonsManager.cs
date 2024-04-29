using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour, IPointerDownHandler
{
    public Image buttonsMenu;
    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonDisable;
    public Button buttonBack;
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonsMenu.gameObject.SetActive(true);
        buttonOne.gameObject.SetActive(true);
        buttonTwo.gameObject.SetActive(true);
        buttonDisable.gameObject.SetActive(true);
        buttonBack.gameObject.SetActive(true);
    }
}
