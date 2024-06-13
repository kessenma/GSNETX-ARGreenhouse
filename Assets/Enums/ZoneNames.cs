using System;
using System.ComponentModel;

/// <summary>
/// Names for the different AR zones
/// Add description to make it look better in the pop-up
/// </summary>
[Serializable]
public enum ZoneNames
{
    None,
    [Description("Zone A")]
    ZoneA,
    [Description("Zone B")]
    ZoneB,
    [Description("Zone C")]
    ZoneC,
    [Description("Zone D")]
    ZoneD,
    [Description("Zone Demo")]
    ZoneDemo,
    ZoneHayden,
    ZoneAmy,
    ZoneSam,
    ZoneBridget,
    ZoneBodric
}