using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeviceOrientationActor : MonoBehaviour
{
    public GameObject deviceOrientationPanel;
    public TMP_Text zonesLeftTMP;
    public GameObject zonesGO;
    public CompletedZones userCompletedZones;
    private Slider xSlider;
    private Slider zSlider;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        xSlider = deviceOrientationPanel.transform.GetChild(0).GetComponent<Slider>();
        zSlider = deviceOrientationPanel.transform.GetChild(1).GetComponent<Slider>();
        zonesLeftTMP.text = "A, B, C, D";
        SetZonesLeft();
        count = 0;
    }

    // Update is called once per frame, but only updates the slider 1/6th of the time
    void Update()
    {
        if(count % 6 == 0)
        {
            xSlider.value = (float)Math.Round((decimal)Input.acceleration.x, 2) * 100;
            zSlider.value = (float)Math.Round((decimal)Input.acceleration.z, 2) * 100;
        }
        count++;
    }

    /// <summary>
    /// Enabled the deviceOrientationPanel, in response to an event
    /// </summary>
    public void EnablePanel()
    {
        deviceOrientationPanel.SetActive(true);
        zonesGO.SetActive(true);
        SetZonesLeft();
    }

    /// <summary>
    /// Disabled the deviceOrientationPanel, in response to an event
    /// </summary>
    public void DisablePanel()
    {
        deviceOrientationPanel.SetActive(false);
        zonesGO.SetActive(false);
    }

    private void SetZonesLeft()
    {
        List<string> allZones = new List<String>();
        var finishedZones = userCompletedZones.GetCompletedZones();
        if(!finishedZones.Contains(ZoneNames.ZoneA))
        {
            allZones.Add("A");
        }
        if(!finishedZones.Contains(ZoneNames.ZoneB))
        {
            allZones.Add("B");
        }
        if(!finishedZones.Contains(ZoneNames.ZoneC))
        {
            allZones.Add("C");
        }
        if (!finishedZones.Contains(ZoneNames.ZoneD))
        {
            allZones.Add("D");
        }

        zonesLeftTMP.text = String.Join(", ", allZones);
    }
}
