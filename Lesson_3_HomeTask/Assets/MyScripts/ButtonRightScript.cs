using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRightScript : MonoBehaviour, IPointerClickHandler
{
    public JetListControl jetListControl;
    public void OnPointerClick(PointerEventData eventData)
    {
        jetListControl.ChangeJetOnButtonRight();
    }
}
