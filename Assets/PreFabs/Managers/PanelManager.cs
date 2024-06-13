using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public List<GameObject> panels;
    public GameObject helpPanel;
    public GameEvent GoToNextScene;
    public GameEvent GoToPreviousScene;
    public GameEvent PanelActivatedSuccessfully;
    public GameEvent EnableNextButton;
    public SceneVisitedData visitedData;

    private int activePanelIndex = -1; //Index of the only active page/panel

    void Awake()
    {
        // iterate over panel set, skip first visible panel
        for(int i=0; i<panels.Count; i++)
        {
            panels[i].SetActive(false);
        }

        // deactivate help panel
        helpPanel.SetActive(false);

        if (visitedData.GetVisited(SceneManager.GetActiveScene().buildIndex))
        {
            //set current active panel to the last one
            activePanelIndex = panels.Count - 1;

        }
        else
        {
            // set current active panel to the first one
            activePanelIndex = 0;

        }

        //set the active page to active and notify the system that a new page appeared
        panels[activePanelIndex].SetActive(true);
        PanelActivatedSuccessfully.Raise();
    }

    /// <summary>
    /// Advance to next panel if possible, otherwise go advance scene
    /// </summary>
    public void GoToNextPanel()
    {
        // if we are on the last panel raise GoToNextScene, otherwise advance panel
        if (activePanelIndex == panels.Count-1)
        {
            visitedData.SetVisited(SceneManager.GetActiveScene().buildIndex);
            GoToNextScene.Raise();
        }
        else
        {
            panels[activePanelIndex].SetActive(false);
            activePanelIndex++;
            panels[activePanelIndex].SetActive(true);
            //Free up the next button and signal that a panel was changed
            EnableNextButton.Raise();
            PanelActivatedSuccessfully.Raise();
        }
        
    }

    /// <summary>
    /// Retreat to the previous panel if possible, otherwise retreat to previous scene
    /// </summary>
    public void GoToPreviousPanel()
    {
        if (activePanelIndex == 0)
        {
            GoToPreviousScene.Raise();
        }
        else
        {
            panels[activePanelIndex].SetActive(false);
            activePanelIndex--;
            panels[activePanelIndex].SetActive(true);
            //Free up the next button and signal that a panel was changed
            EnableNextButton.Raise();
            PanelActivatedSuccessfully.Raise();
        }
    }

    /// <summary>
    /// Set the help panel to active if possible
    /// </summary>
    public void OpenHelpPanel()
    {
        if (helpPanel != null)
        {
            helpPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("The help panel was not found!");
        }
    }

    /// <summary>
    /// Set the help panel to inactive if possible
    /// </summary>
    public void CloseHelpPanel()
    {
        if (helpPanel != null)
        {
            helpPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("The help panel was not found!");
        }
    }


}
