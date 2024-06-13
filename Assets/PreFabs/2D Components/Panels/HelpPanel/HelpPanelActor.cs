using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpPanelActor : MonoBehaviour
{
    public HelpPanel helpPanel;
    public TMP_Text settingsTitle_TMP; //Text object to set the text of
    public TMP_Text helpText_TMP; //Text object to set the text of
    public bool useAsSettingsMenu = false; //Change the implementation behavior to that of a settings menu
    public GameObject confirmationPanel;
    public GameObject confirmationBlur;
    public PopUpStatus popUpStatus;

    private bool hasConfirmationPanels;

    // Start is called before the first frame update
    void Start()
    {
        if(settingsTitle_TMP != null)
        {
            settingsTitle_TMP.text = helpPanel.settingsTitle;
        }
        if (!useAsSettingsMenu)
        {
            helpText_TMP.text = helpPanel.helpText;
        }

        hasConfirmationPanels = confirmationPanel != null && confirmationBlur != null;
        if (hasConfirmationPanels)
        {
            confirmationPanel.SetActive(false);
            confirmationBlur.SetActive(false);
        }
        
    }

    ///<summary>Sets the screen brightness to the value of the slider (0-1)</summary>
    public void ChangeBrightness(float sliderValue)
    {
        Screen.brightness = sliderValue;
    }

    public void CloseConfirmationPopUp()
    {
        if(hasConfirmationPanels)
        {
            confirmationPanel.SetActive(false);
            confirmationBlur.SetActive(false);
        }
        
        
    }

    public void ClosePopUp()
    {
        CloseConfirmationPopUp();
        gameObject.SetActive(false);


    }

    public void ShowConfirmationPopUp()
    {
        if (hasConfirmationPanels)
        {
            confirmationPanel.SetActive(true);
            confirmationBlur.SetActive(true);
           
        }
        
    }
}
