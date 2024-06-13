using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CareerBadgeActor : MonoBehaviour
{
    // declare variables
    public Career Career;
    public bool isBadgeBlue;
    public GameObject blueBadge;
    public GameObject yellowBadge;

    // text objects on career badge
    public TextMeshProUGUI careerTitle_TMP;
    public TextMeshProUGUI careerSkill_1_TMP;
    public TextMeshProUGUI careerSkill_2_TMP;
    public TextMeshProUGUI careerSkill_3_TMP;


    // set scriptable objects equal to text objects
    public void Start()
    {
        // on career badge
        careerTitle_TMP.text = Career.careerTitle;
        careerSkill_1_TMP.text = Career.careerSkill_1;
        careerSkill_2_TMP.text = Career.careerSkill_2;
        careerSkill_3_TMP.text = Career.careerSkill_3;

        // determine which color badge to display
        if (isBadgeBlue)
        {
            blueBadge.SetActive(true);
            yellowBadge.SetActive(false);
        }
        else
        {
            yellowBadge.SetActive(true);
            blueBadge.SetActive(false);
        }
    }

}
