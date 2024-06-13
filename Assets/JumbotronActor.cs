using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumbotronActor : MonoBehaviour
{
    public GameObject jumbotronContainer;
    public GameEvent enableNextButton;
    public GameEvent disableNextButton;

    /// <summary>
    /// Turns on the jumbotron and enables the next button
    /// </summary>
    public void ActivateJumbotron()
    {
        jumbotronContainer.SetActive(true);
        enableNextButton.Raise();
    }

    /// <summary>
    /// sets the state of the next button based on the state of the jumbotron
    /// </summary>
    public void ToggleNextButtonStatus()
    {
        if (jumbotronContainer.activeSelf)
        {
            enableNextButton.Raise();
        }
        else
        {
            disableNextButton.Raise();
        }
    }
}
