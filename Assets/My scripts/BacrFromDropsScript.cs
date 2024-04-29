using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BacrFromDropsScript : MonoBehaviour, IPointerDownHandler
{
    public Image mainMenu;
    public Button buttons;
    public Button toggles;
    public Button drops;
    public Button input;
    public Button scrollView;
    public void OnPointerDown(PointerEventData eventData)
    {
        mainMenu.gameObject.SetActive(true);
        buttons.gameObject.SetActive(true);
        toggles.gameObject.SetActive(true);
        drops.gameObject.SetActive(true);
        input.gameObject.SetActive(true);
        scrollView.gameObject.SetActive(true);
    }
}
