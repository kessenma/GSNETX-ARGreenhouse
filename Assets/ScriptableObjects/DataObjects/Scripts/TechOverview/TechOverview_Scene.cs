using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scenes/TechOverview/Scene", fileName = "TechOverview_Scene")]
public class TechOverview_Scene : ScriptableObject
{
    public TechOverview_Page1 Page1;
    public TechOverview_Page2 Page2;
    public TechOverview_TransitionPage TransitionPage;
    public TechOverview_Page3 Page3;
    public TechOverview_Page4 Page4;
    public TechOverview_Page5 Page5;
    public TechOverview_Page6 Page6;
}
