using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProblemStatement_SceneManager : MonoBehaviour
{

    public ProblemStatement_Scene Scene;
    public Questions questions;

    // page1
    public TMP_Text introTextBubble_textObj;

    // page2
    public TMP_Text title_textObj;
    public TMP_Text subtitle_textObj;
    public TMP_Text cardText1_textObj;
    public TMP_Text cardText2_textObj;
    public TMP_Text cardText3_textObj;
    public TMP_Text cardText5_textObj;

    // page3
    public TMP_Text textBubble3_textObj;

    // page4
    public TMP_Text title4_textObj;
    public TMP_Text textBubble4_textObj;

    // page 5
    public TMP_Text title5_textObj;
    public TMP_Text infographicText01_textObj;
    public TMP_Text infographicText02_textObj;
    public TMP_Text body5_textObj;


    void Start()
    {
        // page1
        introTextBubble_textObj.text = Scene.Page1.introTextBubble;

        // page2
        title_textObj.text = Scene.Page2.title;
        subtitle_textObj.text = Scene.Page2.subtitle;
        cardText1_textObj.text = questions.questions[0];
        cardText2_textObj.text = questions.questions[1];
        cardText3_textObj.text = questions.questions[2];
        cardText5_textObj.text = questions.questions[3];

        // page3
        textBubble3_textObj.text = Scene.Page3.textBubble3;

        // page4
        title4_textObj.text = Scene.Page4.title;
        textBubble4_textObj.text = Scene.Page4.textBubble4;

        // page 5
        title5_textObj.text = Scene.Page5.title;
        infographicText01_textObj.text = Scene.Page5.infographicText01;
        infographicText02_textObj.text = Scene.Page5.infographicText02;
        body5_textObj.text = Scene.Page5.body;

    }
}
