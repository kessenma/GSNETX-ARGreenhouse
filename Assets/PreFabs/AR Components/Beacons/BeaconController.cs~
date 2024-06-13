using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

class BeaconController : MonoBehaviour
{
    // Scriptable Object for persisting beacon status values
    [SerializeField]
    private VirtualObjectSet virtualObjects;

    // Bluetooth status text value
    [SerializeField]
    private StringVariable _statusText;

    // Pirvate list of beacons
    private readonly List<Beacon> _beacons = new List<Beacon>();

    // Co-routine for enabling bluetooth asynchronously
    IEnumerator coroutine;

    // Time to wait inbetween intervals of hecking if bluetooth has been turned on
    readonly private float bluetoothWaitTime = 0.5f;
    readonly private string BEACON_REGION = "GSNETX";
    // iBeacon value to use when ignoring major/minor values
    static private readonly int BEACON_IGNORE = 0;

    /// <summary>
    /// Initializes Bluetooth and registers the BeaconRangeChange event with the iBeacon receiver
    /// </summary>
    private void Start()
    {
        InitReceiver();
        iBeaconReceiver.BeaconRangeChangedEvent += OnBeaconRangeChanged;
        BluetoothState.BluetoothStateChangedEvent += delegate (BluetoothLowEnergyState state) {
            //Debug.Log($"BLE - bluetooth changed: {state}");
            switch (state)
            {
                case BluetoothLowEnergyState.TURNING_OFF:
                case BluetoothLowEnergyState.TURNING_ON:
                    break;
                case BluetoothLowEnergyState.UNKNOWN:
                case BluetoothLowEnergyState.RESETTING:
                    _statusText.Value = "Checking Device…";
                    break;
                case BluetoothLowEnergyState.UNAUTHORIZED:
                    _statusText.Value = "You don't have the permission to use beacons.";
                    break;
                case BluetoothLowEnergyState.UNSUPPORTED:
                    _statusText.Value = "Your device doesn't support beacons.";
                    break;
                case BluetoothLowEnergyState.POWERED_OFF:
                    _statusText.Value = "Enable Bluetooth";
                    break;
                case BluetoothLowEnergyState.POWERED_ON:
                    _statusText.Value = "Bluetooth enabled";
                    break;
                case BluetoothLowEnergyState.IBEACON_ONLY:
                    _statusText.Value = "iBeacon only";
                    break;
                default:
                    _statusText.Value = "Unknown Error";
                    break;
            }
        };
        Debug.Log("BLE - Enabling bluetooth");
        BluetoothState.EnableBluetooth();
        coroutine = StartScan();
        StartCoroutine(coroutine);
    }

    /// <summary>
    /// <a href="https://docs.unity3d.com/Manual/Coroutines.html">Co-routine</a> for waiting for BLE to be turned on and start iBeacon scanning.
    /// </summary>
    /// <returns>Enumerator that waits for BLE to be enabled</returns>
    private IEnumerator StartScan()
    {
        // Bluetooth has to be turned on
        // Unitl bluetooth is on, wait for the state to change indefinitely
        while (BluetoothState.GetBluetoothLEStatus() != BluetoothLowEnergyState.POWERED_ON)
        {
            //Debug.Log($"BLE - Waiting for BLE with state: {BluetoothState.GetBluetoothLEStatus()}");
            yield return new WaitForSeconds(bluetoothWaitTime);
        }
        iBeaconReceiver.Scan();
        Debug.Log("BLE - Now listening for iBeacons");
        yield break;
    }

    /// <summary>
    /// Beacon change event handler.
    /// </summary>
    /// <param name="beacons">The current list of beacons picked up by the iBeaconReceiver</param>
    private void OnBeaconRangeChanged(Beacon[] beacons)
    {
        Array.ForEach(beacons, b => {
            //Debug.Log($"BLE - beacon detected: {b}");
        });
        AddBeacons(beacons);
        RemoveOldBeacons();
        PersistBeaconValues();
    }

    /// <summary>
    /// Adds the given beacons to the interal beacon list, updating beacons already added.
    /// </summary>
    /// <param name="beacons">Beacons to add to the beacon list</param>
    private void AddBeacons(Beacon[] beacons)
    {
        foreach (Beacon b in beacons)
        {
            var index = _beacons.IndexOf(b);
            if (index == -1)
            {
                _beacons.Add(b);
            }
            else
            {
                _beacons[index] = b;
            }
        }
    }

    /// <summary>
    /// Removes old, expired beacons that haven't been detected for 10 seconds
    /// </summary>
    private void RemoveOldBeacons()
    {
        _beacons.FindAll(b => b.lastSeen.AddSeconds(10) < DateTime.Now).ForEach(b => _beacons.Remove(b));
    }

    /// <summary>
    /// Persists the dynamic data values for this beacon to its correspondng VirtualObjectBase.
    /// </summary>
    /// <param name="b">The beacon to use for getting data values to persist</param>
    private void SetBeaconProperties(Beacon b)
    {

        var virtualObjectList = virtualObjects.Items.Where((obj) => obj.ObjectId.Equals(b.ObjectId));
        foreach(VirtualObjectBase vo in virtualObjectList)
        {
            if (vo != null && b.accuracy != -1)
            {
                vo.range = b.range;
                vo.distance = b.accuracy;
                //Debug.Log($"BLE - set range and distance for minor {vo.minor}: r: {vo.range} d: {vo.distance}");
            }
        }
        
    }

    /// <summary>
    /// Updates each Beacon's corresponding VirtualObjectBase with its dynamic values.
    /// </summary>
    private void PersistBeaconValues()
    {
        _beacons.ForEach(SetBeaconProperties);
    }

    /// <summary>
    /// Initialize the iBeaconReceiver with the appropriate iBeaconRegion that matches all Beacon values
    /// </summary>
    private void InitReceiver()
    {
        // Create the general Beacon region for the default UUID
        // the BEACON_IGNORE value is used as a 'wildcard' for all major/minor values
        // i.e., the iBeaconReceiver will look for ALL matching beacons with the DEFAULT_UUID and ANY Major/Minor value
        var beacon = new iBeaconRegion(BEACON_REGION, new Beacon(VirtualObjectBase.DEFAULT_UUID, BEACON_IGNORE, BEACON_IGNORE));
        // Set the regions appropriately for the receiver to listen for
        iBeaconReceiver.regions = new iBeaconRegion[] { beacon };

        //Debug.Log($"BLE - iBeaconRegions used for the iBeaconReceiver, 0 is wildcard for major/minor");
        Array.ForEach(iBeaconReceiver.regions, b => {
            Debug.Log($"BLE - iBeacon region: {b}");
        });
    }
}