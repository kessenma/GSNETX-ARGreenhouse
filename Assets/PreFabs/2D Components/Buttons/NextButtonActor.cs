using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonActor : MonoBehaviour
{
    public GameObject buttonBlocker; //Panel that changes the look of the button
    public GameObject nextButton;
    public GameObject mainMenuButton;

    /// <summary>
    /// Disabled the next panel button
    /// </summary>
    public void DeactivateButton(){
        buttonBlocker.SetActive(true);
        nextButton.GetComponent<Button>().enabled = false;
    }

    /// <summary>
    /// Enabled the next panel button
    /// </summary>
    public void ActivateButton(){
        buttonBlocker.SetActive(false);
        nextButton.GetComponent<Button>().enabled = true;
    }

    ///<summary> deactivate 'Next' button and activate the 'Main Menu' button to change SVG on last panel of last scene </summary>
    public void SwitchNextToMainMenuButton()
    {
        nextButton.SetActive(false);
        mainMenuButton.SetActive(true);
    }

    public void SwitchMainMenuToNextButton()
    {
        nextButton.SetActive(true);
        mainMenuButton.SetActive(false);
    }
}
