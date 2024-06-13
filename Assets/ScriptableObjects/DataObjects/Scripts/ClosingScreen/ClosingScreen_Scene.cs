using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scenes/Closing/Scene", fileName = "ClosingScreen_Scene")]
public class ClosingScreen_Scene : ScriptableObject
{
    // add page names
    public Collaboration_Panel CollabPage;
    public ClosingScreen_Page1 Page1;
    public ClosingScreen_Page2 Page2;
    public ClosingScreen_Page3 Page3;
    public ClosingScreen_Page4 Page4;
}
