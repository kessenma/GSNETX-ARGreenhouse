using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VirtualObjectContainer : MonoBehaviour
{
    public VirtualObjectSet virtualObjects;
    public ZoneVariable activeZone;
    public GameObject virtualObjectPrefab;
    public GameObject zoneLoadedPrefab;
    //time for pop up to display on screen before disapperaing in seconds
    public float shortIndicatorDelay = 5.0f;
    public ZoneOrigins zoneOrigins;
    public GameObject zoneCompletedPrefab;
    public GameObject categoryCompletedPrefab;
    public GameObject huntCompletedPrefab;
    public GameObject remiZoneScanHelper;
    public PopUpStatus popUpStatus;
    public CompletedZones userCompletedZones;
    public GameEvent huntCompleted;
    public GameEvent ActivateImageRecognition;
    public GameEvent DeactivateImageRecognition;
    public GameEvent foundCountsInitialized;
    public GameEvent disableDeviceOrientationPanel;
    public GameEvent enableDeviceOrientationPanel;
    public GameEvent newZoneLoaded;
    public Canvas sceneCanvas;

    // world origin cube
    public GameObject worldOriginCube;

    // public bool to skipp tutorial logic
    //public bool SkipTutorial; 

    // Dictionary of zones, accessible by their corresponding zone names
    private readonly Dictionary<ZoneNames, GameObject> zones = new Dictionary<ZoneNames, GameObject>();

    //variables used to keep state of the zone loaded indiactor
    private ZoneNames lastActiveZone = ZoneNames.None;
    private GameObject zoneLoadIndicator;
    private GameObject zoneCompletedPopUp;
    private GameObject categoryCompletedPopUp;
    private GameObject huntCompletedPopUp;
    public GameEvent minimizeSideBar;

    //ensures we dont start a second coroutine if one is already running to show the indicator
    private bool isLoadIndicatorOnScreen = false;
    //private Canvas sceneCanvas;
    private int longIndicatedDelay = 15;
    private bool imageRecognitionActive;
    private Camera aRCamera;
    private const float TILT_MARGIN = 0.07f;
    // private bool zoneChangeEnabledByTutorial = false;
    //private bool zoneInProgress = false;
    private bool zoneChangeEnabled = false;

    // debugging tools
    private bool onDebugTick = false;
    private int counter = 0;
       


    
    // Start is called before the first frame update
    void Start()
    {
        popUpStatus.aPopUpIsOnScreen = false;
        Instantiate2DPanels();
        virtualObjects.InitializeFoundCounts();

        if (!userCompletedZones.IsHuntCompleted())
        {
            // Create zones
            foreach (ZoneNames zone in Enum.GetValues(typeof(ZoneNames)))
            {
                var zoneObject = new GameObject(zone.ToString());
                zoneObject.transform.SetParent(transform, false);
                zones.Add(zone, zoneObject);
            }
            DeactivteZones();
            DisableZoneChange();
            disableDeviceOrientationPanel.Raise();

            if (userCompletedZones.hasUserCompletedTutorial() )
            {
                
                EnableZoneChange();
                enableDeviceOrientationPanel.Raise();
                virtualObjects.UpdateFoundCounts();
                
            }            
        }
        else
        {
            
            //minimizeSideBar.Raise();
            HuntCompleted();
        }

    }

    private void Instantiate2DPanels()
    {
        //Find a canvas to put the indicator on, we don't care which canvas
        //sceneCanvas = FindObjectOfType<Canvas>();
        zoneLoadIndicator = Instantiate(zoneLoadedPrefab, sceneCanvas.transform, false);
        zoneLoadIndicator.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        zoneLoadIndicator.SetActive(false);
        zoneCompletedPopUp = Instantiate(zoneCompletedPrefab, sceneCanvas.transform, false);
        zoneCompletedPopUp.SetActive(false);
        categoryCompletedPopUp = Instantiate(categoryCompletedPrefab, sceneCanvas.transform, false);
        categoryCompletedPopUp.SetActive(false);
        huntCompletedPopUp = Instantiate(huntCompletedPrefab, sceneCanvas.transform, false);
        huntCompletedPopUp.SetActive(false);
        remiZoneScanHelper.SetActive(false);// already exists in scene 


        //Find and set the arCamera
        aRCamera = FindObjectOfType<Camera>();
    }

    public void Update()
    {
        Debug.Log($"t- Entered VOC.Update; zoneChangeEnabled: {zoneChangeEnabled}, popUpOnScreen: {popUpStatus.aPopUpIsOnScreen}, activeZone.Value: {activeZone.Value},  LastActiveZone: {lastActiveZone}, imageRecognitionActive: {imageRecognitionActive}, loadIndicatorOnScreen: {isLoadIndicatorOnScreen}");

        //Make sure the tutorial is okay with changing zones and there are no pop ups
        if (zoneChangeEnabled && !popUpStatus.aPopUpIsOnScreen)
        {

            UpdateImageRecognitionBasedOnTilt();

            // If any zone is active
            if (activeZone.Value != ZoneNames.None)
            {
                
                //If image recognition is active, the active zone has changed, and the load indicator is not on the screen
                if (imageRecognitionActive && activeZone.Value != lastActiveZone && !isLoadIndicatorOnScreen)
                {
                    logOnCertainTicks($"t- Entered VOC.Update.Inner loop to disable image Recognition");

                    DisableImageRecognition();
                    DisableZoneChange();
                    disableDeviceOrientationPanel.Raise();
                    //Change the zone and tell the user about it
                    StartCoroutine(ToggleLoadIndicator(activeZone.Value));
                    SetZoneOrigin(activeZone.Value);
                    lastActiveZone = activeZone.Value;
                    newZoneLoaded.Raise(); // raises event for second to last tutorial slide progression

                }
            }
            else
            {
                // Otherwise de-activate inactive zone objects
                //Debug.Log("Hayden - deactivated active zone: " + activeZone.Value.ToString());
                DeactivteZones();
            }
        }

    }

    private void logOnCertainTicks(string stringToLog)
    {
        // log every x game ticks
        if(counter % 60 == 0)
        {
            Debug.Log(stringToLog);
        }
        if(counter % 6000 == 0)
        {
            Debug.Log("Counter hit 6000 game ticks and now reseting");
            counter = 0; 
        }
        counter++;

    }

    public void EnableZoneChange()
    {
        zoneChangeEnabled = true;
        StartCoroutine(ToggleRemiHelpZoneScan());

    }

    public void DisableZoneChange()
    {
        zoneChangeEnabled = false;
        remiZoneScanHelper.SetActive(false); // turn of scan helper
    }

    private void DisableImageRecognition()
    {
        DeactivateImageRecognition.Raise();
        imageRecognitionActive = false;

    }

    private void EnableImageRecognition()
    {
        ActivateImageRecognition.Raise();
        imageRecognitionActive = true;
    }

    private IEnumerator ToggleMustFinishZonePopUp()
    {
        isLoadIndicatorOnScreen = true;
        zoneLoadIndicator.SetActive(true);
        zoneLoadIndicator.GetComponent<ZoneLoadedIndicatorActor>().SetText("You must finish the current zone before advancing.");
        yield return new WaitForSeconds(shortIndicatorDelay);
        zoneLoadIndicator.SetActive(false);
        isLoadIndicatorOnScreen = false;
    }

    private void UpdateImageRecognitionBasedOnTilt()
    {
        if (DeviceTilted())
        {
            DisableImageRecognition();
        }
        else
        {
            EnableImageRecognition();
        }
    }

    private void SetZoneOrigin(ZoneNames zone)
    { 
        DeactivteZones();

        //Determine which zone needs to be updated in world space

        zones[zone].transform.position = zoneOrigins.Dictionary[zone].position;
        Debug.Log("T- ZoneObjects transform.position: " + zoneOrigins.Dictionary[zone].position);
        Debug.Log("T- ZoneObjects transform.parent.position: " + zoneOrigins.Dictionary[zone].parent.position);


        Debug.Log("T- ARCamera transform.position: " + aRCamera.transform.position);
        Debug.Log("T- ARCamera transform.parent.position: " + aRCamera.transform.parent.position);

        Debug.Log("T- WorldOriginCube transform.position: " + worldOriginCube.transform.position);



        var rotationAxis = aRCamera.transform.up;// origin always spawns with y+ straight up 
        var angle = Vector3.SignedAngle(worldOriginCube.transform.forward, aRCamera.transform.forward, rotationAxis);
        Debug.Log($"Sean - angle - {angle}");

        //rotates zone object to allign with camera
        //zones[zone].transform.LookAt(aRCamera.transform.position);

        //only instantiate if zone is not already instatiated
        if (zones[zone].transform.childCount <= 0)
        {
            InstantiateObjectsInZone(zone, angle, rotationAxis);
            
        }
        zones[zone].SetActive(true);
       
        
    }

    private void InstantiateObjectsInZone(ZoneNames zone, float angle, Vector3 trueWorldUp)
    {
        foreach (var virtualObjectData in virtualObjects.Items)
        {
            if (virtualObjectData.zoneName == zone)
            {                
                var virtualObject = Instantiate(virtualObjectPrefab, zones[zone].transform, false);
                var actor = virtualObject.GetComponent<VirtualObjectActor>();
                actor.Init(virtualObjectData.name, virtualObjectData, angle, trueWorldUp);
            }
        }
    }

    private void DeactivteZones()
    {
        foreach (var zone in zones)
        {
            zone.Value.SetActive(false);
        }
    }

    //Nicely prints vector3s, helpful for debugging
    private void PrintVector(string leadingText, Vector3 t)
    {
        Debug.Log(leadingText + " (" + t.x + ", " + t.y + ", " + t.z + ")");
    }
    private void PrintQuat(string leadingText, Quaternion t)
    {
        Debug.Log(leadingText + "w: " + t.w + " (" + t.x + ", " + t.y + ", " + t.z + ")");
    }

    /// <summary>
    /// Count how many objects are in each zone and include it on the popup when the zone image is scanned
    /// </summary> 
    private IEnumerator ToggleLoadIndicator(ZoneNames zoneName)
    {
        int countObjectsInZone = virtualObjects.Items.Where(vo => vo.zoneName == zoneName).Count();
        isLoadIndicatorOnScreen = true;
        zoneLoadIndicator.SetActive(true);
        zoneLoadIndicator.GetComponent<ZoneLoadedIndicatorActor>().SetText("<b>Loaded " + zoneName.ToDescription() + "</b>" +
            "\n\n You must find ALL " + countObjectsInZone + " objects in this zone to continue.\n\n Make sure to check behind you!");
        yield return new WaitForSeconds(shortIndicatorDelay);
        zoneLoadIndicator.SetActive(false);
        isLoadIndicatorOnScreen = false;
    }

    /// <summary>
    /// The event handler to call whenever a new object is found to signal updating counts
    /// </summary>
    public void OnFoundObject()
    {
        virtualObjects.UpdateFoundCounts();
        virtualObjects.CheckFoundCounts();
    }
    
   public void ZoneCompleted()
   {
       Debug.Log("T- enter zone Completed");
       StartCoroutine(ToggleZoneCompletedPopUp());
       EnableZoneChange();
       enableDeviceOrientationPanel.Raise();
   }
   


    private IEnumerator ToggleZoneCompletedPopUp()
    {
        zoneCompletedPopUp.SetActive(true);        
        zoneCompletedPopUp.GetComponent<ZoneCompletedPopUpActor>().UserCompletedZone(activeZone.Value);
        yield return new WaitForSeconds(longIndicatedDelay);
        zoneCompletedPopUp.SetActive(false);

    }

    private IEnumerator ToggleRemiHelpZoneScan()
    {
        yield return new WaitForSeconds(longIndicatedDelay);// 20 seconds before showing helper
        Debug.Log($"Entered Toggle remi Help Zone and ZoneChangeEnabled == {zoneChangeEnabled}");

        if (zoneChangeEnabled)
        {
            remiZoneScanHelper.SetActive(true);
        }
    }

    public void HuntCompleted()
    {
        huntCompletedPopUp.SetActive(true);
        DisableZoneChange();
        disableDeviceOrientationPanel.Raise();
        popUpStatus.aPopUpIsOnScreen = true;
    }

    public void SensorCategoryCompleted()
    {
        StartCoroutine(ToggleCategoryPopUp(CategoryNames.Sensors));
    }

    public void AppAndSoftwareCategoryCompleted()
    {
        StartCoroutine(ToggleCategoryPopUp(CategoryNames.AppAndSoftware));
    }

    public void SustainabilityCategoryComplete()
    {
        StartCoroutine(ToggleCategoryPopUp(CategoryNames.SustainabilityAndFarming));
    }

    public void SystemsCategoryCompleted()
    {
        StartCoroutine(ToggleCategoryPopUp(CategoryNames.Systems));
    }

    private IEnumerator ToggleCategoryPopUp(CategoryNames category)
    {
        
        categoryCompletedPopUp.SetActive(true);       
        categoryCompletedPopUp.GetComponent<CategoryFoundActor>().SetCategory(category); 
        yield return new WaitForSeconds(shortIndicatorDelay);
        categoryCompletedPopUp.SetActive(false);
    }
    
    private bool DeviceTilted()
    {

        return Input.acceleration.x > TILT_MARGIN || Input.acceleration.x < -TILT_MARGIN
                || (Input.acceleration.y + 1) > TILT_MARGIN || (Input.acceleration.y + 1) < -TILT_MARGIN
                || Input.acceleration.z > TILT_MARGIN || Input.acceleration.z < -TILT_MARGIN;

    }

    public void SkipHunt()
    {
        userCompletedZones.userHasCompletedTutorial = true;
        userCompletedZones.huntSkipped = true;
        HuntCompleted();
    }



}
