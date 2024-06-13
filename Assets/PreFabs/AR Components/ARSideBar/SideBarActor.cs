using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBarActor : MonoBehaviour
{
    public GameObject sideBarMaximized;
    public GameObject sideBarMinimized;
    public GameObject helpPanel;
    public GameEvent toggleSideBar;
    public GameEvent minimizeSideBar;

    private bool maximized;

    /// <summary>
    /// Sets the state to maximized
    /// </summary>

    void Start()
    {
        
        sideBarMaximized.SetActive(true);
        sideBarMinimized.SetActive(false);
        maximized = true;        
    }

    /// <summary>
    /// Move from minimized to maximized or vice versa
    /// </summary>
    public void ToggleVisibility()
    {
        if (maximized)
        {
            sideBarMaximized.SetActive(false);
            sideBarMinimized.SetActive(true);
        }
        else
        {
            sideBarMaximized.SetActive(true);
            sideBarMinimized.SetActive(false);
        }

        maximized = !maximized;
    }

    /// <summary>
    /// Minimize the side bar
    /// </summary>
    public void MinimizeSideBar()
    {
        maximized = false;
        sideBarMaximized.SetActive(false);
        sideBarMinimized.SetActive(true);
    }

    /// <summary>
    /// Opens the help panel
    /// </summary>
    public void OpenHelpPanel()
    {
        helpPanel.SetActive(true);
        MinimizeSideBar();
        minimizeSideBar.Raise();
        helpPanel.GetComponent<HelpPanelActor>().popUpStatus.PopUpSpawned();
    }

    /// <summary>
    /// Closes the help panel
    /// </summary>
    public void CloseHelpPanel()
    {
        helpPanel.GetComponent<HelpPanelActor>().popUpStatus.PopUpDespawned();
        helpPanel.SetActive(false);
        
    }
}
