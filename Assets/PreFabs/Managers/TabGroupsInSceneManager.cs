using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroupsInSceneManager : MonoBehaviour
{
    public List<TabGroupManager> tabGroups;
    public GameEvent enableNextPanelButton;
    public GameEvent disableNextPanelButton;

    private int activeTabGroupIndex = -1; //Index of the only active tab group in the scene
    private bool nextButtonEnableEventRaised = false;

    /// <summary>
    /// Listens for a tab group to be setActive in the scene, and
    /// then sets up the tab group and the state of the next panel button
    /// </summary>
    public void PanelActivatedSuccessfullyResponse()
    {
        activeTabGroupIndex = -1;
        //Locate currently active tab group
        for (int i=0; i<tabGroups.Count; i++)
        {
            if (tabGroups[i].gameObject.activeInHierarchy) {
                activeTabGroupIndex = i;
                break;
            }
        }

        //If a tab group is actually on screen
        if(activeTabGroupIndex > -1)
        {
            //Setup said tab group
            tabGroups[activeTabGroupIndex].Setup();
            nextButtonEnableEventRaised = false;

            //Modify the functionaity of the next button
            if (!tabGroups[activeTabGroupIndex].FullyVisited())
            {
                disableNextPanelButton.Raise();
            }
            else
            {
                //otherwise ensure the next button is not locked
                enableNextPanelButton.Raise();
                nextButtonEnableEventRaised = true;
            }
        }
        
    }



    /// <summary>
    /// Listens for the next tab event, and switches to the next tab in the active tab group
    /// </summary>
    public void NextTabResponse()
    {
        tabGroups[activeTabGroupIndex].NextTab();
        if (tabGroups[activeTabGroupIndex].FullyVisited() && !nextButtonEnableEventRaised)
        {
            //free up the next button if the tabs have been fully navigated
            nextButtonEnableEventRaised = true;
            enableNextPanelButton.Raise();
        }
    }


    /// <summary>
    /// Lisetns for the previous tab event, and switches to the previous tab in the active tab group
    /// </summary>
    public void PreviousTabResponse()
    {
        tabGroups[activeTabGroupIndex].PreviousTab();
    }

}
