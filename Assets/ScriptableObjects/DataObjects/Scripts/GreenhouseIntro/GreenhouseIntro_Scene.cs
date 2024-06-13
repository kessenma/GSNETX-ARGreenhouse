using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scenes/GreenhouseIntro/Scene", fileName = "GreenhouseIntro_Scene")]
public class GreenhouseIntro_Scene : ScriptableObject
{
    public const string SceneName = "Greenhouse Intro";
    public GreenhouseIntro_IntroPage introPage;
    public GreenhouseIntro_TabPage tabPage, farmingStyles;
    public GreenhousePlantingStylesPage1 plantingStylesPage1;
    public GreenhouseIntro_Phase1Page phase1Page;
    public GreenhouseIntro_Phase2Page phase2Page;
    public GreenhouseIntro_Phase3Page phase3Page;
}
