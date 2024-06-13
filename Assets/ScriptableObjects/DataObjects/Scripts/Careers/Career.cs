using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scenes/Careers/Career", fileName = "Career")]
public class Career : ScriptableObject
{
    // on career badge
    public string careerTitle; // this will also be on the hero shot
    public string careerSkill_1;
    public string careerSkill_2;
    public string careerSkill_3;

    // on career hero shot
    public string careerDesciption;
    public int careerSalaryMin; // only accept number input
    public int careerSalaryMax; // only accept number input
    public string careerEducationReq;
    public string relatedActivity;

    // tracker
    public bool isVisited; // tracks if the career has been clicked on
}