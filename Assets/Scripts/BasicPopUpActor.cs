using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPopUpActor : MonoBehaviour
{
    public GameObject popUp;

    public void ActivatePopUp()
    {
        popUp.SetActive(true);
    }

    public void DeActivatePopUp()
    {
        popUp.SetActive(false);
    }
}