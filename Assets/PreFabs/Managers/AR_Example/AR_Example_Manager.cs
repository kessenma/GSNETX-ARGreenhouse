using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AR_Example_Manager : MonoBehaviour
{
    [SerializeField]
    private Text statusText;
    [SerializeField]
    private GameObject scrollViewContent;
    [SerializeField]
    private GameObject beaconDebugPrefab;
    [SerializeField]
    private VirtualObjectSet virtualObjects;

    [SerializeField]
    private StringVariable status;

    public void Start()
    {
        var yOffset = 0;
        var yOffsetIncrement = BeaconDebug.HEIGHT;
        virtualObjects.Items.ForEach(b =>
        {
            var beaconDebugContainer = Instantiate(beaconDebugPrefab, scrollViewContent.transform);
            var rectTransform = beaconDebugContainer.GetComponent<RectTransform>();
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, yOffset, yOffsetIncrement);
            Debug.Log($"BLE - Created virtual object UI at position {beaconDebugContainer.transform.position}");
            yOffset += yOffsetIncrement;

            var debug = beaconDebugContainer.GetComponent<BeaconDebug>();
            debug.SetVirtualObject(b);
        });
    }

    public void Update()
    {
        statusText.text = status.Value;
    }
}
