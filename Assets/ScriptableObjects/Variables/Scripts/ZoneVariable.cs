using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/ZoneVariable", fileName = "ActiveZone")]
public class ZoneVariable : ScriptableObject
{
    [SerializeField]
    private ZoneNames value = ZoneNames.None;

    public ZoneNames Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public static ZoneNames GetZoneName(string zoneName)
    {
        return (ZoneNames)Enum.Parse(typeof(ZoneNames), zoneName);
    }
}
