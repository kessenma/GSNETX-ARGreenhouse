using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBarStateManager : MonoBehaviour
{
    public VirtualObjectSet setOfObjects;
    public GameEvent soilMoistureFound;
    public GameEvent cameraFound;
    public GameEvent lightingFound;
    public GameEvent temperatureFound;
    public GameEvent soilPlanterFound;
    public GameEvent dataFound;
    public GameEvent controlFound;
    public GameEvent wateringFound;
    public GameEvent weatherFound;
    public GameEvent hydroponicsFound;
    public GameEvent aquaponicsFound;
    public GameEvent composingFound;
    public GameEvent cloudDataFound;
    public GameEvent rainFound;

    private void Start()
    {
        UpdateSideBar();  
    }

    /// <summary>
    /// Called when the update side bar event is raised. Updates the side bar progress.
    /// </summary>
    public void UpdateSideBar()
    {
        Debug.Log("Hayden - Update side bar");
        if (setOfObjects) {
            Dictionary<ObjectNames, FoundCounter> objectsDictionary = setOfObjects.GetObjectCounts();

            foreach (KeyValuePair<ObjectNames, FoundCounter> entry in objectsDictionary)
            {
                for (int i = 0; i < entry.Value.actualFoundCount; i++)
                {
                    GetEventToRaise(entry.Key)?.Raise();
                    Debug.Log("Hayden - Found item");
                }
            }
        }
        Debug.Log("Hayden - finish Update side bar");
    }

    private GameEvent GetEventToRaise(ObjectNames key)
    {
        switch (key)
        {
            case ObjectNames.SoilMoistureSensor:
                return soilMoistureFound;
            case ObjectNames.Camera:
                return cameraFound;
            case ObjectNames.LightingSensor:
                return lightingFound;
            case ObjectNames.TemperatureSensor:
                return temperatureFound;
            case ObjectNames.SoilPlanter:
                return soilPlanterFound;
            case ObjectNames.DataPipeline:
                return dataFound;
            case ObjectNames.AutomatedControllSystem:
                return controlFound;
            case ObjectNames.AutomatedWateringSystem:
                return wateringFound;
            case ObjectNames.WeatherStationSystem:
                return weatherFound;
            case ObjectNames.Hydroponics:
                return hydroponicsFound;
            case ObjectNames.Aquaponics:
                return aquaponicsFound;
            case ObjectNames.Composting:
                return composingFound;
            case ObjectNames.CloudDatabase:
                return cloudDataFound;
            case ObjectNames.RainCollectionSystem:
                return rainFound;
            default:
                return null;
        }
    }
}
