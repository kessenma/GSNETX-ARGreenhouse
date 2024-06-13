using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Careers_SceneManager : MonoBehaviour
{
    // Declare Scene
    public Careers_Scene Scene;

    // Declare objects on PAGE 1 of scene
    public TextMeshProUGUI careerBuilding_TMP;

    // Declare objects on PAGE 2 of scene
    public TextMeshProUGUI careerBuildingTitle_TMP;

    // Declare objects on PAGE 3 of scene
    public TextMeshProUGUI careerMaintaining_TMP;

    // Declare objects on PAGE 4 of scene
    public TextMeshProUGUI careerMainTitle_TMP;

    //Liking system
    public LikingSystem likingData;
    public GameObject recommendedPanel1;
    public GameObject recommendedPanel2;
    public GameEvent goToNextPanel;
    public GameEvent goToPreviousPanel;
    public TextMeshProUGUI remiTextLikedObjects;
    public TextMeshProUGUI likedObjects;
    public TextMeshProUGUI remiTextCareerCategory;
    public TextMeshProUGUI careerList;
    public bool goingForward = true;

    // Connect the scriptale objects to the objects
    public void Start()
    {
        // PAGE 1
        careerBuilding_TMP.text = Scene.Page1.careerBuilding;

        // PAGE 2
        careerBuildingTitle_TMP.text = Scene.Page2.explorationMessage;

        // PAGE 3
        careerMaintaining_TMP.text = Scene.Page3.careerMaintaining;

        // PAGE 4
        careerMainTitle_TMP.text = Scene.Page4.careerMainHeader;
    }

    /// <summary>
    /// Sets the direction of navigation to forward
    /// </summary>
    public void Forward()
    {
        goingForward = true;
    }

    /// <summary>
    /// Sets the direction of navigation to backward
    /// </summary>
    public void Backward()
    {
        goingForward = false;
    }

    /// <summary>
    /// Populates the recommended panel
    /// </summary>
    public void PopulateRecPanel()
    {
        if ((goingForward && recommendedPanel1.activeInHierarchy) || (!goingForward && recommendedPanel2.activeInHierarchy))
        {
            
            remiTextLikedObjects.text = likingData.GetRemiLikedObjectsText();
            likedObjects.text = likingData.GetLikedObjects();
            remiTextCareerCategory.text = likingData.GetRemiCareerCategoryText();
            careerList.text = likingData.GetCareerList();
            
        }
    }
}
