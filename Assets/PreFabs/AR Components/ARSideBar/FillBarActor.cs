using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VectorGraphics;
using TMPro;

public class FillBarActor : MonoBehaviour
{
    public TMP_Text titleObject; //TMP object to represent the title of the fill bar
    public Slider fillBar; //Slider object to represent the fill bar
    public int numberOfObjectsToFind; //Number of objects to be found on the scavenger hunt will also go in a scriptable object later
    public string title; //This will be replaced with a scriptable object in the future

    private int numberOfObjectsFound = 0;

    private void Start()
    {
        titleObject.text = title;
    }

    /// <summary>
    /// When an object is found increase the fill bar to its new level
    /// </summary>
    public void ObjectFound()
    {
        if(numberOfObjectsFound < numberOfObjectsToFind)
        {
            numberOfObjectsFound++;
            fillBar.value = (float)numberOfObjectsFound / numberOfObjectsToFind;
        }
    }
}
