﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Handlers/SceneHandler", fileName = "SceneHandler")]
public class SceneHandler : ScriptableObject
{
    // This class leverages the built in Unity Scene Manager but by placing it in this class
    // we can avoid the need to place it or reference it within in scene which could vary based
    // on each scene implementation

    // PUBLIC VARIABLES
    public IntVariable mainMenuSceneBuildIndex; // store the build index of the main menu as scriptable object
    public IntVariable pauseScreenBuildIndex; // store the pause screen build index as scriptable object


    // PRIVATE VARIABLES
    private int totalScenes; // total number of scenes
    private int currentSceneIndex; // current scene index


    //METHODS
    public void OnEnable()
    {
        //helper function only works if in editor, so call this to get the accurate number of scenes. This issue not present when deployed.
        if(Application.isEditor)
        {
            totalScenes = GetActiveScenesInBuildSettingsNames().Length; // total number of scenes
        }
        else
        {
            totalScenes = SceneManager.sceneCountInBuildSettings;
        }

        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // current scene index
        //If deployed and index is -1 or less, set it to the first scene
        if(currentSceneIndex < 0)
        {
            currentSceneIndex = 0;
        }
        
    }


    private static string[] GetActiveScenesInBuildSettingsNames()
    {
        List<string> temp = new List<string>();

#if UNITY_EDITOR
        foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
        {
            if (S.enabled)
            {
                string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                name = name.Substring(0, name.Length - 6);
                temp.Add(name);
            }
        }
#endif
        return temp.ToArray();
    }



    // method to load the next scene
    public void GoToNextScene()
    {
        // load the next scene if not at the last scene
        if (currentSceneIndex < totalScenes - 1)
        {
            // determine the next scene
            currentSceneIndex++;
            // load the next scene
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            // print error message
            Debug.Log("There is no next scene.");
        }
    }

    // method to load the previous scene
    public void GoToPreviousScene()
    {
        // load the previous scene if not at the first scene
        if (currentSceneIndex > 0)
        {
            // determine the previous scene
            currentSceneIndex--;
            // load the previous scene
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            // print error message
            Debug.Log("There is no previous scene.");
        }
    }

    // method to load the main menu
    public void GoToMenu()
    {
        // update currentSceneIndex
        currentSceneIndex = mainMenuSceneBuildIndex.Value;
        // load the menu scene
        SceneManager.LoadScene(currentSceneIndex);
    }

    // method to load the pause scene
    public void DisplayPauseScene()
    {
        // update currentSceneIndex
        currentSceneIndex = pauseScreenBuildIndex.Value;
        // load the menu scene
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void RestartApplication()
    {
        Application.Quit();

    }
}
