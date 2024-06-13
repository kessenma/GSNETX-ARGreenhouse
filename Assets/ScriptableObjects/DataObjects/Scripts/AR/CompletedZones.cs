using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AR/Completed Zones", fileName = "CompletedZones")]
public class CompletedZones : ScriptableObject
{
    private List<ZoneNames> zonesUserHasCompleted = new List<ZoneNames>();
    public int numberOfZonesInHunt { get; private set; } = 4;
    public bool skipTutorial;
    public bool userHasCompletedTutorial = false;
    public bool huntSkipped = false;

    public bool IsZoneAlreadyCompleted(ZoneNames zone)
    {
        foreach (ZoneNames z in zonesUserHasCompleted)
        {
            if (z == zone)
            {
                return true;
            }
        }
        return false;
    }

    public void UserCompletedZone(ZoneNames zone)
    {
        if(!IsZoneAlreadyCompleted(zone))
        {
            zonesUserHasCompleted.Add(zone);
        }
    }

    public List<ZoneNames> GetIncompleteZones()
    {
        var ret = new List<ZoneNames>();
        foreach (ZoneNames zone in Enum.GetValues(typeof(ZoneNames)))
        {
            if(!zonesUserHasCompleted.Contains(zone))
            {
                ret.Add(zone);
            }
        }
            return ret;
    }

    public List<ZoneNames> GetCompletedZones()
    {
        return zonesUserHasCompleted;
    }

    public bool IsHuntCompleted()
    {
        foreach(ZoneNames zone in zonesUserHasCompleted)
        {
            Debug.Log("T-Sam - completed zone: " + zone);
        }

        return GetCompletedZones().Count == numberOfZonesInHunt || huntSkipped;
    }

    public bool hasUserCompletedTutorial()
    {
        Debug.Log($"t- userHasCompetedTutorial: {userHasCompletedTutorial}, skipTutorial: {skipTutorial}");
        return userHasCompletedTutorial || skipTutorial;
    }

    public void SetUserCompletedTutorialToTrue()
    {
        userHasCompletedTutorial = true;
    }


    public void Reset()
    {
        zonesUserHasCompleted.Clear();
        userHasCompletedTutorial = false;
        huntSkipped = false;
    }





}
