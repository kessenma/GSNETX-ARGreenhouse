using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scenes/Careers/Scene", fileName = "Careers_Scene")]
public class Careers_Scene : ScriptableObject
{
    // list all of pages in the scene
    public Careers_Page1 Page1;
    public Careers_Page2 Page2;
    public Careers_Page3 Page3;
    public Careers_Page4 Page4;
    public Careers_PanelPopUp PanelPopUp;
}