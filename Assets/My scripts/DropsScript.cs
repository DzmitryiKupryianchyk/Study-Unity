using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropsScript : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TMP_Text textMeshPro;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
    }

    private void DropdownValueChanged(TMP_Dropdown changedDropdown)
    {
        textMeshPro.text = changedDropdown.options[changedDropdown.value].text;
    }
}
