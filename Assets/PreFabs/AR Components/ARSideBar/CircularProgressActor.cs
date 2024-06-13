using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CircularProgressActor : MonoBehaviour
{
    public GameObject title; //TMP object to represent the title of the fill bar
    public TMP_Text count; // EX "15 of 20"
    public Image loadingIcon;
    public GameObject regularIcon;
    public GameObject completedIcon;
    public int numberOfObjectsToFind; //Number of objects to be found on the scavenger hunt will also go in a scriptable object later
    private int numberOfObjectsFound = 0;
    private bool maximized;

    /// <summary>
    /// Sets the state to maximized
    /// </summary>
    void Start()
    {
        title.gameObject.SetActive(true);
        count.gameObject.SetActive(true);
        if (numberOfObjectsFound >= numberOfObjectsToFind)
        {
            regularIcon.SetActive(false);
            completedIcon.SetActive(true);
        }
        else
        {
            regularIcon.SetActive(true);
            completedIcon.SetActive(false);
        }
        loadingIcon.fillAmount = (float)numberOfObjectsFound / numberOfObjectsToFind;
        count.text = numberOfObjectsFound.ToString() + " of " + numberOfObjectsToFind.ToString();
        maximized = true;
    }

    /// <summary>
    /// When an object is found increase the fill bar to its new level
    /// </summary>
    public void ObjectFound()
    {
        if (numberOfObjectsFound < numberOfObjectsToFind)
        {
            numberOfObjectsFound++;
            count.text = numberOfObjectsFound.ToString() + " of " + numberOfObjectsToFind.ToString();
            loadingIcon.fillAmount = (float)numberOfObjectsFound / numberOfObjectsToFind;
        }
        if (numberOfObjectsFound == numberOfObjectsToFind)
        {
            regularIcon.SetActive(false);
            completedIcon.SetActive(true);
        }
    }

    /// <summary>
    /// Shows/hides the progress text
    /// </summary>
    public void ToggleText()
    {
        if (maximized)
        {
            title.SetActive(false);
            count.gameObject.SetActive(false);
        }
        else
        {
            title.SetActive(true);
            count.gameObject.SetActive(true);
        }
        maximized = !maximized;
    }

    /// <summary>
    /// Hides the progress text
    /// </summary>
    public void Minimize()
    {
        title.SetActive(false);
        count.gameObject.SetActive(false);
        maximized = false;
    }
}












