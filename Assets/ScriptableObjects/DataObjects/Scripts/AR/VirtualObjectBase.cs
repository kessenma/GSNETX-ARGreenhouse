using System;
using UnityEngine;

[CreateAssetMenu(menuName = "AR/Virtual Object", fileName = "VirtualObject")]
public class VirtualObjectBase : ScriptableObject
{
    public static readonly string DEFAULT_UUID = "f7bd22e8-121a-4105-b7f2-e5c94f01d197";
    // Virtual Object values
    public ZoneNames zoneName;

    // we change this name
    public VirtualGreenhouseItem virtualGreenhouseItem;
    public Vector3 offset;
    public bool isAPopUpOnScreen = false;
    // Game state values
    [HideInInspector]
    public bool isFound = false;

    // Beacon values
    public string UUID = DEFAULT_UUID;
    public int major;
    public int minor;
    [HideInInspector]
    public BeaconRange range;
    [HideInInspector]
    public double distance;
    [HideInInspector]
    public string ObjectId
    {
        get
        {
            return (UUID + "_" + major + "_" + minor).ToLower();
        }
    }

    public override string ToString()
    {
        return $"Major: {major}, Minor: {minor}, range: {range}, distance: {distance}, isFound: {isFound}";
    }
}
