using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBackManager : MonoBehaviour, IPointerDownHandler
{
    public Image buttonsMenu;
    public Image mainMenu;
    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonDisable;
    public Button buttonBack;
    public TMP_Text thisText;
    public Button buttons;
    public Button toggles;
    public Button drops;
    public Button input;
    public Button scrollView;
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        buttonOne.gameObject.SetActive(false);
        buttonTwo.gameObject.SetActive(false);
        buttonDisable.gameObject.SetActive(false);
        buttonBack.gameObject.SetActive(false);
        thisText.gameObject.SetActive(false);
        buttons.gameObject.SetActive(true);
        toggles.gameObject.SetActive(true);
        drops.gameObject.SetActive(true);
        input.gameObject.SetActive(true);
        scrollView.gameObject.SetActive(true);
    }
}
