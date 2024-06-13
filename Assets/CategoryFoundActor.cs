using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CategoryFoundActor : MonoBehaviour
{
    public GameObject sensorIcons;
    public GameObject sustainabilityIcons;
    public GameObject appSoftwareIcons;
    public GameObject systemsIcons;

    public TMP_Text categoryText;

    private CategoryNames categoryName = CategoryNames.None;

    public void SetCategory(CategoryNames category)
    {
        categoryName = category;
        ResetOtherIcons();
        switch(categoryName)
        {
            case CategoryNames.AppAndSoftware :                
                categoryText.text = "App and Software Items";
                appSoftwareIcons.SetActive(true);
                break;
            case CategoryNames.Sensors:
                categoryText.text = "Sensors";
                sensorIcons.SetActive(true);
                break;
            case CategoryNames.SustainabilityAndFarming:
                categoryText.text = "Sustainability and Farming Items";
                sustainabilityIcons.SetActive(true);
                break;
            case CategoryNames.Systems:
                categoryText.text = "Systems";
                systemsIcons.SetActive(true);
                break;
        }
    }

    private void ResetOtherIcons()
    {
        sensorIcons.SetActive(false);
        appSoftwareIcons.SetActive(false);
        sustainabilityIcons.SetActive(false);
        systemsIcons.SetActive(false);
    }


}
