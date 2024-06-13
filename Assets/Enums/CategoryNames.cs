using System;
using System.ComponentModel;

/// <summary>
/// Names for the different categories
/// </summary>
[Serializable]
public enum CategoryNames
{
    [Description("None")]
    None,
    [Description("Sensors")]
    Sensors,
    [Description("Systems")]
    Systems,
    [Description("App and Software ")]
    AppAndSoftware,
    [Description("Sustainability And Farming")]
    SustainabilityAndFarming
}
