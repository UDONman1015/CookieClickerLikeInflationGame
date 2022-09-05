using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ButtonInteractable : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = this.GetComponent<Button>();
    }

    public void OnClick()
    {
        if (button != null)
        {
            button.interactable = false;
            button.interactable = true;
        }
    }
}
