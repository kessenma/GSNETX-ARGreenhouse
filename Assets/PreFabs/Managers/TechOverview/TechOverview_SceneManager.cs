using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TechOverview_SceneManager : MonoBehaviour
{
    public TechOverview_Scene Scene;

    // Page 1
    public TMP_Text introText_textObj;

    // Page 2
    public TMP_Text techUsedTitle_textObj;
    public TMP_Text techUsedBody_textObj;
    public TMP_Text listItem1_textObj;
    public TMP_Text listItem2_textObj;
    public TMP_Text listItem3_textObj;
    public TMP_Text listItem4_textObj;

    // Transition Page
    public TMP_Text transitionText_TMP;

    // Page 3
    public TMP_Text walkthroughTitleThree_textObj;
    public TMP_Text remiTextBubbleThree_textObj;
    public TMP_Text sensorTextThree_textObj;
    public TMP_Text appSoftwareTextThree_textObj;
    public TMP_Text systemsTextThree_textObj;
    public TMP_Text farmingSustainabilityTextThree_textObj;
    //jumbotron text objects
    public TMP_Text titleTextSensors_TMP;
    public TMP_Text exampleTitleSensors_TMP;
    public TMP_Text exampleTextSensors_TMP;
    public TMP_Text puposeTitleSensors_TMP;
    public TMP_Text purposeTextSensors_TMP;
    public TMP_Text careerTitleSensors_TMP;
    public TMP_Text careerTextSensors_TMP;
    public TMP_Text nextTextSensors_TMP;

    //Page 4
    public TMP_Text walkthroughTitleFour_textObj;
    public TMP_Text remiTextBubbleFour_textObj;
    public TMP_Text sensorTextFour_textObj;
    public TMP_Text appSoftwareTextFour_textObj;
    public TMP_Text systemsTextFour_textObj;
    public TMP_Text farmingSustainabilityTextFour_textObj;
    //jumbotron text objects
    public TMP_Text titleTextApps_TMP;
    public TMP_Text exampleTitleApps_TMP;
    public TMP_Text exampleTextApps_TMP;
    public TMP_Text puposeTitleApps_TMP;
    public TMP_Text purposeTextApps_TMP;
    public TMP_Text careerTitleApps_TMP;
    public TMP_Text careerTextApps_TMP;
    public TMP_Text nextTextApps_TMP;

    //Page 5
    public TMP_Text walkthroughTitleFive_textObj;
    public TMP_Text remiTextBubbleFive_textObj;
    public TMP_Text sensorTextFive_textObj;
    public TMP_Text appSoftwareTextFive_textObj;
    public TMP_Text systemsTextFive_textObj;
    public TMP_Text farmingSustainabilityTextFive_textObj;
    //jumbotron text objects
    public TMP_Text titleTextSystems_TMP;
    public TMP_Text exampleTitleSystems_TMP;
    public TMP_Text exampleTextSystems_TMP;
    public TMP_Text puposeTitleSystems_TMP;
    public TMP_Text purposeTextSystems_TMP;
    public TMP_Text careerTitleSystems_TMP;
    public TMP_Text careerTextSystems_TMP;
    public TMP_Text nextTextSystems_TMP;

    //Page 6
    public TMP_Text walkthroughTitleSix_textObj;
    public TMP_Text remiTextBubbleSix_textObj;
    public TMP_Text sensorTextSix_textObj;
    public TMP_Text appSoftwareTextSix_textObj;
    public TMP_Text systemsTextSix_textObj;
    public TMP_Text farmingSustainabilityTextSix_textObj;
    //jumbotron text objects
    public TMP_Text titleTextFarming_TMP;
    public TMP_Text exampleTitleFarming_TMP;
    public TMP_Text exampleTextFarming_TMP;
    public TMP_Text puposeTitleFarming_TMP;
    public TMP_Text purposeTextFarming_TMP;
    public TMP_Text careerTitleFarming_TMP;
    public TMP_Text careerTextFarming_TMP;
    public TMP_Text nextTextFarming_TMP;

    void Start() 
    {
        // Page 1
        introText_textObj.text = Scene.Page1.introText;

        // Page 2
        techUsedTitle_textObj.text = Scene.Page2.techUsedTitle;
        techUsedBody_textObj.text = Scene.Page2.techUsedBody;
        listItem1_textObj.text = Scene.Page2.listItem1;
        listItem2_textObj.text = Scene.Page2.listItem2;
        listItem3_textObj.text = Scene.Page2.listItem3;
        listItem4_textObj.text = Scene.Page2.listItem4;

        // transition page
        transitionText_TMP.text = Scene.TransitionPage.transitionText;

        // Page 3
        walkthroughTitleThree_textObj.text = Scene.Page3.walkthroughTitle;
        remiTextBubbleThree_textObj.text = Scene.Page3.remiTextBubble;
        sensorTextThree_textObj.text = Scene.Page3.sensorText;
        appSoftwareTextThree_textObj.text = Scene.Page3.appSoftwareText;
        systemsTextThree_textObj.text = Scene.Page3.systemsText;
        farmingSustainabilityTextThree_textObj.text = Scene.Page3.farmingSustainabilityText;
        // jumbotron
        titleTextSensors_TMP.text = Scene.Page3.titleText;
        exampleTitleSensors_TMP.text = Scene.Page3.exampleTitle;
        exampleTextSensors_TMP.text = Scene.Page3.exampleText;
        puposeTitleSensors_TMP.text = Scene.Page3.purposeTitle;
        purposeTextSensors_TMP.text = Scene.Page3.purposeText;
        careerTitleSensors_TMP.text = Scene.Page3.careerTitle;
        careerTextSensors_TMP.text = Scene.Page3.careerText;
        nextTextSensors_TMP.text = Scene.Page3.nextText;

        //Page 4
        walkthroughTitleFour_textObj.text = Scene.Page4.walkthroughTitle;
        remiTextBubbleFour_textObj.text = Scene.Page4.remiTextBubble;
        sensorTextFour_textObj.text = Scene.Page4.sensorText;
        appSoftwareTextFour_textObj.text = Scene.Page4.appSoftwareText;
        systemsTextFour_textObj.text = Scene.Page4.systemsText;
        farmingSustainabilityTextFour_textObj.text = Scene.Page4.farmingSustainabilityText;
        // jumbotron
        titleTextApps_TMP.text = Scene.Page4.titleText;
        exampleTitleApps_TMP.text = Scene.Page4.exampleTitle;
        exampleTextApps_TMP.text = Scene.Page4.exampleText;
        puposeTitleApps_TMP.text = Scene.Page4.purposeTitle;
        purposeTextApps_TMP.text = Scene.Page4.purposeText;
        careerTitleApps_TMP.text = Scene.Page4.careerTitle;
        careerTextApps_TMP.text = Scene.Page4.careerText;
        nextTextApps_TMP.text = Scene.Page4.nextText;

        //Page 5
        walkthroughTitleFive_textObj.text = Scene.Page5.walkthroughTitle;
        remiTextBubbleFive_textObj.text = Scene.Page5.remiTextBubble;
        sensorTextFive_textObj.text = Scene.Page5.sensorText;
        appSoftwareTextFive_textObj.text = Scene.Page5.appSoftwareText;
        systemsTextFive_textObj.text = Scene.Page5.systemsText;
        farmingSustainabilityTextFive_textObj.text = Scene.Page5.farmingSustainabilityText;
        // jumbotron
        titleTextSystems_TMP.text = Scene.Page5.titleText;
        exampleTitleSystems_TMP.text = Scene.Page5.exampleTitle;
        exampleTextSystems_TMP.text = Scene.Page5.exampleText;
        puposeTitleSystems_TMP.text = Scene.Page5.purposeTitle;
        purposeTextSystems_TMP.text = Scene.Page5.purposeText;
        careerTitleSystems_TMP.text = Scene.Page5.careerTitle;
        careerTextSystems_TMP.text = Scene.Page5.careerText;
        nextTextSystems_TMP.text = Scene.Page5.nextText;


        //Page 6
        walkthroughTitleSix_textObj.text = Scene.Page6.walkthroughTitle;
        remiTextBubbleSix_textObj.text = Scene.Page6.remiTextBubble;
        sensorTextSix_textObj.text = Scene.Page6.sensorText;
        appSoftwareTextSix_textObj.text = Scene.Page6.appSoftwareText;
        systemsTextSix_textObj.text = Scene.Page6.systemsText;
        farmingSustainabilityTextSix_textObj.text = Scene.Page6.farmingSustainabilityText;
        // jumbotron
        titleTextFarming_TMP.text = Scene.Page6.titleText;
        exampleTitleFarming_TMP.text = Scene.Page6.exampleTitle;
        exampleTextFarming_TMP.text = Scene.Page6.exampleText;
        puposeTitleFarming_TMP.text = Scene.Page6.purposeTitle;
        purposeTextFarming_TMP.text = Scene.Page6.purposeText;
        careerTitleFarming_TMP.text = Scene.Page6.careerTitle;
        careerTextFarming_TMP.text = Scene.Page6.careerText;
        nextTextFarming_TMP.text = Scene.Page6.nextText;
    }


}
