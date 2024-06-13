using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeaconDebug : MonoBehaviour
{
    public Text range;
    public Text distance;
    public Text isFoundText;
    public Text major;
    public Text minor;

    private VirtualObjectBase _virutalObject;
    static public readonly int HEIGHT = 380;

    // Update is called once per frame
    void Update()
    {
        if (_virutalObject != null)
        {
            range.text = _virutalObject.range.ToString();
            distance.text = _virutalObject.distance.ToString();
            isFoundText.text = _virutalObject.isFound.ToString();
            major.text = _virutalObject.major.ToString();
            minor.text = _virutalObject.minor.ToString();
        }
    }

    public void SetVirtualObject(VirtualObjectBase virutalObject)
    {
        Debug.Log($"BLE - SetVirtualObject with values: {virutalObject}");
        _virutalObject = virutalObject;
    }

}
