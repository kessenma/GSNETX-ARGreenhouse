using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AR/Pop Up Status", fileName = "PopUpStatus")]
public class PopUpStatus : ScriptableObject
{
    public bool aPopUpIsOnScreen = false;

    public void PopUpSpawned()
    {
        aPopUpIsOnScreen = true; 
    }

    public void PopUpDespawned()
    {
        aPopUpIsOnScreen = false;
    }
}
