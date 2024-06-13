using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoneLoadedIndicatorActor : MonoBehaviour
{
   
    public TMP_Text zoneName;

    /// <summary>
    /// Specify which zone we are seeing
    /// </summary> 
    public void SetText(string zone)
    {
        zoneName.text = zone;
    }
        
    
}
