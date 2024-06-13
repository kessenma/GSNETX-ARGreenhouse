using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroupManager : MonoBehaviour
{
    public List<IndividualTabActor> tabs;
    public GameEvent tabGroupEnabled;

    private int activeTabIndex = -1; //Index of the active tab in the tab group
    private bool alreadyActivated = false; //Allows us to save state between panel changes


    /// <summary>
    /// Set up the tab group by only enabling the first tab
    /// Only triggers the first time the tab group appears in the scene
    /// </summary>
    public void Setup()
    {
        if (!alreadyActivated)
        {
            if (tabs != null)
            {
                //Disable all but the first tab
                for (int i=1; i<tabs.Count; i++)
                {
                    tabs[i].Disable();
                }

                //Enable the first tab
                if (tabs[0] != null)
                {
                    activeTabIndex = 0;
                    tabs[activeTabIndex].Enable();
                }
                else
                {
                    Debug.LogWarning("Tab Group does not have assigned tabs");
                }
            }
            alreadyActivated = true;
        }
               
    }

    /// <summary>
    /// If possible, advances to the next tab
    /// </summary>
    public void  NextTab()
    {
        if(activeTabIndex < tabs.Count - 1 && activeTabIndex >= 0)
        {
            tabs[activeTabIndex].Disable();
            activeTabIndex++;
            tabs[activeTabIndex].Enable();
        }
    }

    /// <summary>
    /// If possible, goes back to the previoustab
    /// </summary>
    public void PreviousTab()
    {
        if(activeTabIndex > 0) {
            tabs[activeTabIndex].Disable();
            activeTabIndex--;
            tabs[activeTabIndex].Enable();
        }
    }

    /// <summary>
    /// Check to see if every tab in the group has been visited
    /// </summary>
    /// <returns>
    /// if all tabs in the group have been visited
    /// </returns>
    public bool FullyVisited()
    {
        foreach (IndividualTabActor tab in tabs)
        {
            if (!tab.getVisited())
            {
                return false;
            }
        }
        return true;
    }
}
