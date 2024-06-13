using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClosingScreen_SceneManager : MonoBehaviour
{

    // DECLARE SCENE
    public ClosingScreen_Scene Scene;
    public GameEvent switchToMainMenuButton;
    public GameEvent switchToNextButton;
    public Acknowledgements acknowledgements;
    public int activePanelIndex = 1;
    public Questions questions;

    // DECLARE OBJECTS BY PAGE NUMBER

    // collab page
    public TextMeshProUGUI collabTitle_TMP;
    public TextMeshProUGUI collabPrompt_TMP;
    public TextMeshProUGUI Question_1_TMP;
    public TextMeshProUGUI Question_2_TMP;
    public TextMeshProUGUI Question_3_TMP;
    public TextMeshProUGUI Question_4_TMP;

    // page 1
    public TextMeshProUGUI thankYou_textObj;

    // page 2
    public TextMeshProUGUI namesHeader_textObj;
    public TextMeshProUGUI name1_textObj;
    public TextMeshProUGUI name2_textObj;
    public TextMeshProUGUI name3_textObj;
    public TextMeshProUGUI name4_textObj;
    public TextMeshProUGUI name5_textObj;
    public TextMeshProUGUI name6_textObj;
    public TextMeshProUGUI name7_textObj;
    public TextMeshProUGUI name8_textObj;
    public TextMeshProUGUI name9_textObj;
    public TextMeshProUGUI name10_textObj;
    public TextMeshProUGUI name11_textObj;
    public TextMeshProUGUI name12_textObj;
    public TextMeshProUGUI name13_textObj;
    public TextMeshProUGUI name14_textObj;
    public TextMeshProUGUI name15_textObj;
    public TextMeshProUGUI name16_textObj;
    public TextMeshProUGUI name17_textObj;
    public TextMeshProUGUI name18_textObj;
    public TextMeshProUGUI name19_textObj;
    public TextMeshProUGUI name20_textObj;
    public TextMeshProUGUI name21_textObj;
    public TextMeshProUGUI name22_textObj;
    public TextMeshProUGUI name23_textObj;
    public TextMeshProUGUI name24_textObj;
    public TextMeshProUGUI name25_textObj;
    public TextMeshProUGUI name26_textObj;
    public TextMeshProUGUI name27_textObj;
    public TextMeshProUGUI name28_textObj;
    public TextMeshProUGUI name29_textObj;
    public TextMeshProUGUI name30_textObj;

    // page 3
    public TextMeshProUGUI goodbye_textObj;

    // page 4
    public TextMeshProUGUI contrats_textObj;

    // set the string values to their corresponding text object
    public void Start()
    {
        // collab page
        collabTitle_TMP.text = Scene.CollabPage.collabTitle;
        collabPrompt_TMP.text = Scene.CollabPage.collabPrompt;
        Question_1_TMP.text = questions.questions[0];
        Question_2_TMP.text = questions.questions[1];
        Question_3_TMP.text = questions.questions[2];
        Question_4_TMP.text = questions.questions[3];

        // page 1
        thankYou_textObj.text = Scene.Page1.thankYouMessage;

        // page 2
        namesHeader_textObj.text = acknowledgements.namesTitle;
        name1_textObj.text = acknowledgements.names[0];
        name2_textObj.text = acknowledgements.names[1];
        name3_textObj.text = acknowledgements.names[2];
        name4_textObj.text = acknowledgements.names[3];
        name5_textObj.text = acknowledgements.names[4];
        name6_textObj.text = acknowledgements.names[5];
        name7_textObj.text = acknowledgements.names[6];
        name8_textObj.text = acknowledgements.names[7];
        name9_textObj.text = acknowledgements.names[8];
        name10_textObj.text = acknowledgements.names[9];
        name11_textObj.text = acknowledgements.names[10];
        name12_textObj.text = acknowledgements.names[11];
        name13_textObj.text = acknowledgements.names[12];
        name14_textObj.text = acknowledgements.names[13];
        name15_textObj.text = acknowledgements.names[14];
        name16_textObj.text = acknowledgements.names[15];
        name17_textObj.text = acknowledgements.names[16];
        name18_textObj.text = acknowledgements.names[17];
        name19_textObj.text = acknowledgements.names[18];
        name20_textObj.text = acknowledgements.names[19];
        name21_textObj.text = acknowledgements.names[20];
        name22_textObj.text = acknowledgements.names[21];
        name23_textObj.text = acknowledgements.names[22];
        name24_textObj.text = acknowledgements.names[23];
        name25_textObj.text = acknowledgements.names[24];
        name26_textObj.text = acknowledgements.names[25];
        name27_textObj.text = acknowledgements.names[26];
        name28_textObj.text = acknowledgements.names[27];
        name29_textObj.text = acknowledgements.names[28];
        name30_textObj.text = acknowledgements.names[29];

        // page 3
        goodbye_textObj.text = Scene.Page3.goodByeMessage;

        // page 4
        contrats_textObj.text = Scene.Page4.congratsMessage;

        activePanelIndex = 1;
    }

    public void nextPanel()
    {
        activePanelIndex++;
        if(activePanelIndex == 4) {
            switchToMainMenuButton.Raise();
        }

    }


    public void previousPanel()
    {
        if(activePanelIndex == 4)
        {
            switchToNextButton.Raise();
        }
        activePanelIndex--;
    }

}
