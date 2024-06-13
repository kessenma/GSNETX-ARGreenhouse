using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAlreadyScannedActor : MonoBehaviour
{

    public GameObject zoneAlreadyScannedPanel;
    public float timeToShowPanel = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        zoneAlreadyScannedPanel.SetActive(false);  
    }

    /// <summary>
    /// Displays the zoneAlreadyScannedPanel for the given amount of time
    /// </summary>
    public void ZoneAlreadyScanned()
    {
        StartCoroutine(ToggleZoneScannedPanel());
    }

    private IEnumerator ToggleZoneScannedPanel()
    {
        zoneAlreadyScannedPanel.SetActive(true);
        yield return new WaitForSeconds(timeToShowPanel);
        zoneAlreadyScannedPanel.SetActive(false);
    }

}
