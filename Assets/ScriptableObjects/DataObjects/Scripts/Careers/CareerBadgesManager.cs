using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CareerBadgesManager : MonoBehaviour
{
    // Public Variables
    public List<Career> careersSet_Makers; // list of the first set of careers
    public List<Career> careersSet_Maintainers; // list of the first set of careers
    public GameObject careerPage_Makers;
    public GameObject careerPage_Maintainers;
    public GameEvent DisableNextPanelButton; // event to disable next button
    public GameEvent EnableNextPanelButton; // event to enable next button

    // Private Variable
    private int requiredClicks_Makers = 3; // require user to open 3 badges
    private int requiredClicks_Maintainers = 1; // require user to open 1 badge
    private bool allGood_Makers = false;
    private bool allGood_Maintainers = false;

    /// <summary>
    /// check to see if we should disable the next button based on active panel
    /// and the current number of viewed badges
    /// </summary>
    public void checkToDisableNextButton()
    {
        // initially disable the next button to force the user to view a
        // certain number of badges before advancing if a scroll is present
        if ((careerPage_Makers.activeInHierarchy == true && allGood_Makers == false)
            || (careerPage_Maintainers.activeInHierarchy == true && allGood_Maintainers == false))
        {
            DisableNextPanelButton.Raise();
        }
    }

    /// <summary>
    /// determine if the requirements have been made to activate the next button
    /// the required change depending on which scroll is active
    /// scroll 1 requires 3 views and scroll 2 requires 1 view
    /// </summary>
    public void DetermineIfEnoughCareersHaveBeenClicked()
    {
        int count_1 = 0; // counter for first career scrol
        int count_2 = 0; // counter for second career scroll
        // determine if the first scroll is currently active
        if (careerPage_Makers.activeInHierarchy == true)
        {
            // toggle through each career to determine how many have been viewed
            foreach (Career badge1 in careersSet_Makers)
            {
                if (badge1.isVisited)
                {
                    // increase counter if the career has been visited
                    count_1 ++;

                    // if 3 badges have been clicked on, enable the next button
                    if (count_1 >= requiredClicks_Makers)
                    {
                        allGood_Makers = true;
                        // raise event to enable next button
                        EnableNextPanelButton.Raise();
                    }
                }
            }

        }
        // determine if the second scroll is currently active
        else if (careerPage_Maintainers.activeInHierarchy == true)
        {
            // toggle through each career to determine how many have been viewed
            foreach (Career badge2 in careersSet_Maintainers)
            {
                if (badge2.isVisited)
                {
                    // increase counter if the career has been visited
                    count_2 ++;

                    // if 1 badge has been clicked on, enable the next button
                    if (count_2 >= requiredClicks_Maintainers)
                    {
                        allGood_Makers = true;
                        // raise event to enable next button
                        EnableNextPanelButton.Raise();
                    }
                }
            }

        }
    }
}

