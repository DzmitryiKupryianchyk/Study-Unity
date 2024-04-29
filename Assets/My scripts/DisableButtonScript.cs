using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisableButtonScript : MonoBehaviour, IPointerDownHandler
{
    public TextMeshProUGUI textButtons;
    public TextMeshProUGUI textButtonDisable;
    private string originalText;
    private string originalTextForButtonDisable;
    public Button buttonOne;
    public Button buttonTwo;
    void Start()
    {
        originalText = textButtons.text;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonOne.interactable == true & buttonTwo.interactable == true) 
        {
            buttonOne.interactable = false;
            buttonTwo.interactable = false;
            textButtonDisable.text = "Enable";
        }
        else if (buttonOne.interactable == false & buttonTwo.interactable == false)
        {
            buttonOne.interactable = true;
            buttonTwo.interactable = true;
            textButtonDisable.text = "Disable";
        }
        else 
        {
            Debug.LogError("Error. Both 'button one' and 'button two' must be either enabled or disabled simultaniously.");
        }
    }

    
}
