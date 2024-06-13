using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    //Variable Text Objects
    public TextMeshProUGUI remiIntroductionBubble;
    public GameEvent resetData;
    //MainMenu Scriptable Object to set Text
    public MainMenu_Scene sceneData;

    void Start()
    {
        //Set all of the variable text
        remiIntroductionBubble.text = sceneData.remiIntroductionBubble;
        resetData.Raise();
        
    }

    ///<summary>Close the application</summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
