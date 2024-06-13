using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class CareerHeroShotActorScript : MonoBehaviour
{
    // declare variables
    public Career Career;
    public GameObject careerHeroPanel;
    public Careers_Scene Scene;
    public GameEvent CareerOpened;
    public GameEvent DisableNextPanelButton;

    // declare text objects on careers hero shot
    public TextMeshProUGUI careerTitleHeroShot_TMP;
    public TextMeshProUGUI careerDescription_TMP;
    public TextMeshProUGUI careerSalary_TMP;
    public TextMeshProUGUI careerEducationReq_TMP;
    public TextMeshProUGUI relatedActivity_TMP;

    // text that does not change
    public TextMeshProUGUI descriptionTitle_TMPObj;
    public TextMeshProUGUI salaryTitle_TMPObj;
    public TextMeshProUGUI requirementsTitle_TMPObj;
    public TextMeshProUGUI GSBadgesTitle_TMPObj;

    /// <summary>
    /// mark all careers as false initially
    /// </summary>
    public void Awake()
    {
        Career.isVisited = false;
    }

    /// <summary>
    /// assign all text mesh pros to the appropriate text
    /// </summary>
    public void Start()
    {
        careerTitleHeroShot_TMP.text = Career.careerTitle;
        careerDescription_TMP.text = Career.careerDesciption;
        careerSalary_TMP.text = Career.careerSalaryMin.ToString("C0") + " - " + Career.careerSalaryMax.ToString("C0");
        careerEducationReq_TMP.text = Career.careerEducationReq;
        relatedActivity_TMP.text = Career.relatedActivity;

        //Career.isVisited = false;
        // POP-UP Panel
        descriptionTitle_TMPObj.text = Scene.PanelPopUp.descriptionTitle;
        salaryTitle_TMPObj.text = Scene.PanelPopUp.salaryTitle;
        requirementsTitle_TMPObj.text = Scene.PanelPopUp.requirementTitle;
        GSBadgesTitle_TMPObj.text = Scene.PanelPopUp.GSBadgesDescription;
    }

    /// <summary>
    /// Opens up the career hero shot corresponding to that particular career badge and marks the career as viewed
    /// </summary>
    public void OpenCareerHeroShot()
    {
        careerHeroPanel.SetActive(true);
        Career.isVisited = true;
        // raise events
        CareerOpened.Raise();
    }

    /// <summary>
    /// Closes the career hero shot.
    /// </summary>
    public void CloseCareerHeroShot()
    {
        careerHeroPanel.SetActive(false);
    }
}