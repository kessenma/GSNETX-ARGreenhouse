using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static System.Math;

public class ZoneCompletedPopUpActor : MonoBehaviour
{
    public TMP_Text zoneName;
    public GameObject zoneACheck;
    public GameObject zoneBCheck;
    public GameObject zoneCCheck;
    public GameObject zoneDCheck;
    public TMP_Text moveOnPrompt;
    public CompletedZones completedZones;

    public void UserCompletedZone(ZoneNames zone)
    {
        switch (zone)
        {
            case ZoneNames.ZoneA:
                zoneName.text = "Zone A";
                break;
            case ZoneNames.ZoneB:
                zoneName.text = "Zone B";
                break;
            case ZoneNames.ZoneC:
                zoneName.text = "Zone C";
                break;
            case ZoneNames.ZoneD:
                zoneName.text = "Zone D";
                break;
        }

        SetZonesLeftText();
        ShowChecksOnCompletedZones();
        
    }


    private void SetZonesLeftText()
    {
        int zonesLeft = completedZones.numberOfZonesInHunt - completedZones.GetCompletedZones().Count;
        moveOnPrompt.text = "You've got " + zonesLeft + " zones left! Scan the QR codes in the remaining zones (see map).";
    }

    private void ShowChecksOnCompletedZones()
    {
        foreach (ZoneNames zone in completedZones.GetCompletedZones())
        {
            switch (zone)
            {
                case ZoneNames.ZoneA:
                    zoneACheck.SetActive(true);
                    break;
                case ZoneNames.ZoneB:
                    zoneBCheck.SetActive(true);
                    break;
                case ZoneNames.ZoneC:
                    zoneCCheck.SetActive(true);
                    break;
                case ZoneNames.ZoneD:
                    zoneDCheck.SetActive(true);
                    break;
                default:
                    Debug.Log("***No valid zone found for zone check map");
                    break;
            }
        }
    }
}
