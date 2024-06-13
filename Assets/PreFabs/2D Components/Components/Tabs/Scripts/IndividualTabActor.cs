using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IndividualTabActor : MonoBehaviour
{
    
    public GameObject tabBody; //Panel linked to this tab
    
    //style for the tab label
    public Color activeColor;
    public Color inactiveColor;
    public TextMeshProUGUI label;
    public Animator activeTabIndicator;

    private bool isVisited = false;

    /// <summary>
    /// Enables the tab by updating the tab label, showing tab body, and playing animation
    /// </summary>
    public void Enable()
    {
        isVisited = true;

        //Show tab body
        tabBody.SetActive(true);

        //Activate label
        label.color = activeColor;

        //Playing the animation
        activeTabIndicator.SetTrigger("justClicked");
    }

    /// <summary>
    /// Disabled the tab by updating the tab label, hiding tab body, and playing animation
    /// </summary>
    public void Disable()
    {
        label.gameObject.SetActive(true);
        //Hide tab body
        tabBody.SetActive(false);

        //Deactive label
        label.color = inactiveColor;

        //Playing the goodbye animation
        activeTabIndicator.SetTrigger("goodbye");
    }

    /// <summary>
    /// Getter for visited 
    /// </summary>
    /// <returns>
    /// if the tab has been visited
    /// </returns>
    public bool getVisited()
    {
        return isVisited;
    }

}
