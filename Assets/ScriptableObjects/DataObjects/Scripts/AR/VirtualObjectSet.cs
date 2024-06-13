using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(menuName = "Sets/Virtual Object Set", fileName = "VirtualObjectSet")]
public class VirtualObjectSet : RuntimeSet<VirtualObjectBase>
{
    // populating class with data and methods necessary to manage and track a list of virtualObjectBase

    // Dictionary for counts of objects found for each zone, category, and object
    private readonly Dictionary<ZoneNames, FoundCounter> zoneCounts =
        new Dictionary<ZoneNames, FoundCounter>();
    private readonly Dictionary<CategoryNames, FoundCounter> categoryCounts =
        new Dictionary<CategoryNames, FoundCounter>();
    private readonly Dictionary<ObjectNames, FoundCounter> objectCounts =
        new Dictionary<ObjectNames, FoundCounter>();

    public GameEvent zoneCompleted;
    public GameEvent appAndSoftwareCategoryCompleted;
    public GameEvent sensorCategoryCompleted;
    public GameEvent systemsCategoryCompleted;
    public GameEvent sustainabilityCategoryCompleted;
    public GameEvent huntCompleted;
    public GameEvent foundCountsUpdated;
    public CompletedZones userCompletedZones;

    private bool hasInitializedSet = false;

    
    public void InitializeFoundCounts()
    {
        if (!hasInitializedSet) {

            objectCounts.Clear();
            zoneCounts.Clear();
            categoryCounts.Clear();
            
            foreach (var obj in Items)
            {
                if (obj.virtualGreenhouseItem != null)
                {
                    var tempZone = obj.zoneName;
                    if (tempZone == ZoneNames.ZoneA || tempZone == ZoneNames.ZoneB || tempZone == ZoneNames.ZoneC || tempZone == ZoneNames.ZoneD)
                    {
                        AddToRequiredCount(objectCounts, obj.virtualGreenhouseItem.objectName);
                        AddToRequiredCount(categoryCounts, obj.virtualGreenhouseItem.categoryName);
                        AddToRequiredCount(zoneCounts, obj.zoneName);
                    }
                }
                else
                {
                    Debug.Log("Sean/Tyler - Found virtualGreenhouseItem that was null");
                }
            }
            hasInitializedSet = true;
        } 
    }

    /// <summary>
    /// Return the objectCounts dictionary
    /// </summary>
    /// <returns>object counts dictionary</returns>
    public Dictionary<ObjectNames, FoundCounter> GetObjectCounts()
    {
        return objectCounts;
    }

    /// <summary>
    /// Checks if there is a completed object/category/zone
    /// </summary>
    public void CheckFoundCounts()
    {
        CheckFoundCount(categoryCounts, FoundAllItemsInCategorySet);
        CheckFoundCount(zoneCounts, FoundAllItemsInZoneSet);
    }

    /// <summary>
    /// Reclaculates the actualFoundCOunt value for each item for each object/zone/category
    /// </summary>
    public void UpdateFoundCounts()
    {

        ResetFoundCounts();
        foreach (var obj in Items)
        {

            if (obj.virtualGreenhouseItem != null)
            {
              
                var tempZone = obj.zoneName;
                if (tempZone == ZoneNames.ZoneA || tempZone == ZoneNames.ZoneB || tempZone == ZoneNames.ZoneC || tempZone == ZoneNames.ZoneD)
                {
                    if (obj.isFound)
                    {
                        objectCounts[obj.virtualGreenhouseItem.objectName].IncrementActual();
                        categoryCounts[obj.virtualGreenhouseItem.categoryName].IncrementActual();
                        zoneCounts[obj.zoneName].IncrementActual();
                    }
                }
            }
            else
            {
                Debug.Log($"Sean/Tyler - ZoneName: {obj.zoneName}, isFound: {obj.isFound}, VOB.ToString(): {obj},");
            }
        }
        foundCountsUpdated.Raise();
        Debug.Log("Hayden - all object statuses");
        PrintOutResultsInDictionary(objectCounts);
    }



    private void PrintOutResultsInDictionary<T>(Dictionary<T, FoundCounter> dict)
    {
        Debug.Log("T- Entering Print Results of Dictionary; count of Values: " + dict.Values.Count);
        foreach (KeyValuePair<T, FoundCounter> entry in dict)
        {
            Debug.Log($"T- Key: {entry.Key}, Value.FoundCount: {entry.Value.actualFoundCount}, RequiredCount: {entry.Value.requiredFoundCount}");
        }
    }

    private void AddToRequiredCount<T>(Dictionary<T, FoundCounter> dict, T name)
    {
        // Add or update the required found count for this name
        if (dict.ContainsKey(name))
        {
            // Increment the required found count for this name
            dict[name].IncrementRequired();
        }
        else
        {
            // Add the name to the dictionary initializing the required found count required for completion
            dict.Add(name, new FoundCounter());
        }
    }

    /// <summary>
    /// Resets the actualFoundCount for all items in each dictionary
    /// </summary>
    private void ResetFoundCounts()
    {
        ResetFoundCount(objectCounts);
        ResetFoundCount(categoryCounts);
        ResetFoundCount(zoneCounts);
    }

    /// <summary>
    /// Resets the actual found count for each item in the dictionary
    /// </summary>
    private void ResetFoundCount<T>(Dictionary<T, FoundCounter> dict)
    {
        foreach (var obj in dict.Values)
        {
            obj.ResetActual();
        }
    }

    private delegate void CountComplete<T>(T name);

    /// <summary>
    /// Checks if there are any completed counters within the dictionary, performs complete callback
    /// </summary>
    private void CheckFoundCount<T>(Dictionary<T, FoundCounter> dict, CountComplete<T> complete)
    {
        foreach (var obj in dict)
        {           
            if (obj.Value.actualFoundCount == obj.Value.requiredFoundCount && !obj.Value.hasBeenTriggered)
            {
                complete(obj.Key);
                obj.Value.FoundRequiredAmount();
            }
        }
    }    

    private void FoundAllItemsInCategorySet(CategoryNames name)
    {
        switch (name)
        {
            case CategoryNames.Sensors :
                sensorCategoryCompleted.Raise();
                break;
            case CategoryNames.Systems :
                systemsCategoryCompleted.Raise();
                break;
            case CategoryNames.AppAndSoftware :
                appAndSoftwareCategoryCompleted.Raise();
                break;
            case CategoryNames.SustainabilityAndFarming :
                sustainabilityCategoryCompleted.Raise();
                break;
        }
    }

    private void FoundAllItemsInZoneSet(ZoneNames name)
    {
        userCompletedZones.UserCompletedZone(name);
        if (userCompletedZones.IsHuntCompleted())
        {
            huntCompleted.Raise();

        } else
        {
            zoneCompleted.Raise();

        }
    }

    public void ResetFoundStateOfObjects()
    {
        hasInitializedSet = false;
        ResetFoundCounts();
        foreach (var obj in Items)
        {
            if(obj !=null)
            {
                obj.isFound = false;
            }
            
        }
    }
}
