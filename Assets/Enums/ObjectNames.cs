using System;
using System.ComponentModel;

/// <summary>
/// Names for the different objects
/// </summary>
[Serializable]
public enum ObjectNames
{
    None,
    [Description("Soil Moisture Sensor")]
    SoilMoistureSensor,
    [Description("Temperature Sensor")]
    TemperatureSensor,
    [Description("Light Sensor")]
    LightingSensor,
    Camera,
    RainCollectionSystem,
    AutomatedWateringSystem,
    WeatherStationSystem,
    AutomatedControllSystem,
    DataPipeline,
    CloudDatabase,
    Composting,
    SoilPlanter,
    Hydroponics,
    Aquaponics
}