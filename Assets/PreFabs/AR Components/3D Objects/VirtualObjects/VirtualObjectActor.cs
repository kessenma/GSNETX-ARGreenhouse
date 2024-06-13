using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualObjectActor : MonoBehaviour
{
    // Camera in Scene
    private Camera aRCamera;
    // Game object instances for this object, dynamically created from prefabs
    private GameObject nearNotFoundObject;
    private GameObject farNotFoundObject;
    private GameObject nearFoundObject;
    private GameObject popUpPanel;
    private GameObject farFoundObject;

    // Data for this virtual object
    public VirtualObjectBase virtualObject;
    public GameEvent popUpSpawned;
    public GameEvent popUpDespawned;
    public PopUpStatus popUpStatus;
    public GameEvent objectFound;
    public CompletedZones userCompletedZones;
    public bool Testing;
    public TMP_Text positionText;
    public TMP_Text rotationText;
    public GameObject zoneIndicatorPrefab;

    private bool hasInit = false;

    /// <summary>
    /// Create all needed prefab objects and hide all objects that should not show on start
    /// </summary>
    /// <param name="newName">new name of object</param>
    /// <param name="virtualObjectBase">prefab of a virtual object</param>
    public void Init(string newName, VirtualObjectBase virtualObjectBase, float angle, Vector3 rotationAxis)
    {
        name = newName;
        virtualObject = virtualObjectBase;
        aRCamera = FindObjectOfType<Camera>();


        Debug.Log($"T - {newName} position: - {transform.position}");
        Debug.Log($"T - {newName} offset: - {virtualObject.offset}");

        // Working MORE consistently
        var rotatedOffset = Quaternion.AngleAxis(angle, rotationAxis) *virtualObject.offset;
        Debug.Log($"T - {newName} rotatedOffset - {rotatedOffset}");
        transform.position += rotatedOffset;


        Debug.Log($"T - {newName} position + offset - {transform.position}");
        
        // for testing
        if(Testing == true)
        {
            SetPositionAndRotation(transform);
        }

        InstantiateObjects();
        popUpPanel.SetActive(false);
        DeactivateAllObjects();
        Debug.Log($"BLE - created virtual object actor at location {transform.position}");
        hasInit = true;
    }

    /// <summary>
    /// Will change the state of the virtual object based on the user's proximity to the beacon and found state
    /// </summary>
    public void Update()
    {
        if (hasInit)
        {
            HandleTouch();
            
            if (virtualObject.isFound)
            {
                //If found, near and immediate are the same
                //Added the far state to mirror the near state since most of the time the user will be
                //in the far state due to limitations of the beacons. This is not a great solution
                //but was done due to resource contraints.
                if(virtualObject.range == BeaconRange.NEAR || virtualObject.range == BeaconRange.IMMEDIATE || virtualObject.range == BeaconRange.FAR)
                {
                    SetStatesOfObjects(nearFoundObject);
                }
                else if (virtualObject.range == BeaconRange.UNKNOWN )
                {
                    SetStatesOfObjects(farFoundObject, true);
                }
            }
            else
            {
                
                if (virtualObject.range == BeaconRange.NEAR || virtualObject.range == BeaconRange.FAR || virtualObject.range == BeaconRange.IMMEDIATE)
                {
                    SetStatesOfObjects(nearNotFoundObject);
                }
                else if (virtualObject.range == BeaconRange.UNKNOWN)
                {
                    SetStatesOfObjects(farNotFoundObject, true);
                }                
            }
        }
    }

    private void SetPositionAndRotation(Transform transform)
    {
        positionText.text = "Position: " + transform.position.ToString();
        rotationText.text = "Rotation: " + transform.rotation.eulerAngles.ToString();
        
        positionText.transform.LookAt(positionText.transform.position + aRCamera.transform.rotation * Vector3.forward, aRCamera.transform.rotation * Vector3.up);
        rotationText.transform.LookAt(rotationText.transform.position + aRCamera.transform.rotation * Vector3.forward, aRCamera.transform.rotation * Vector3.up);

    }

    private void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // Detect if object is clicked
            if (touch.phase == TouchPhase.Began)
            {              

                //if my pop up is on screen and I clicked out of it 
               if(popUpPanel.activeSelf && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
               {
                   popUpPanel.SetActive(false);
                   popUpDespawned.Raise();                   
               }                
                //else if no pop up is on screen and tutorial is not active, register touch normally
                else if(!popUpStatus.aPopUpIsOnScreen && userCompletedZones.hasUserCompletedTutorial() )
                {
                    Ray raycast = aRCamera.ScreenPointToRay(touch.position);
                    if (RaycastHitThisObject(raycast))
                    {
                        //If in range, find this object
                        if (VirtualObjectIsInSelectableRange())
                        {
                            ShowGreenhouseItem();

                            if (!virtualObject.isFound)
                            {
                                
                                //only send signals the first time it is found
                                TriggerFoundSignals();
                            }
                        } 
                    }
                }
            }
        }
    }

    
    private bool VirtualObjectIsInSelectableRange() 
    {
        return virtualObject.range == BeaconRange.IMMEDIATE || virtualObject.range == BeaconRange.NEAR || virtualObject.range == BeaconRange.FAR || virtualObject.range == BeaconRange.UNKNOWN;
    }


    //determine if the touch hit this object
    private bool RaycastHitThisObject(Ray raycast)
    {
        return Physics.Raycast(raycast, out RaycastHit raycastHit) && GameObject.ReferenceEquals(raycastHit.collider.gameObject, gameObject);
    }

    //TODO make this private after testing
    public void InstantiateObjects()
    {
         nearNotFoundObject = Instantiate(virtualObject.virtualGreenhouseItem.nearNotFoundPrefab, transform);
        farNotFoundObject = Instantiate(virtualObject.virtualGreenhouseItem.farNotFoundPrefab, transform);
        nearFoundObject = Instantiate(virtualObject.virtualGreenhouseItem.nearFoundPrefab, transform);
        farFoundObject = Instantiate(virtualObject.virtualGreenhouseItem.farFoundPrefab, transform);
        popUpPanel = Instantiate(virtualObject.virtualGreenhouseItem.popUpPrefab, FindObjectOfType<Canvas>().transform);
    }

    //TODO make this private after testing
    public void ShowGreenhouseItem()
    {
        SetStatesOfObjects(nearFoundObject);
        popUpPanel.SetActive(true);
        popUpSpawned.Raise();
    }

    //TODO make this private after testing
    public void TriggerFoundSignals()
    {
        virtualObject.isFound = true;
        virtualObject.virtualGreenhouseItem.itemFound.Raise();
        virtualObject.virtualGreenhouseItem.itemInCategoryFound.Raise();
        objectFound.Raise();
    }

    //TODO make this private after testing
    public void HidePopup()
    {
        popUpPanel.SetActive(false);
        popUpDespawned.Raise();
    }

    private void DeactivateAllObjects()
    {
        nearNotFoundObject.SetActive(false);
        farNotFoundObject.SetActive(false);
        nearFoundObject.SetActive(false);
        farFoundObject.SetActive(false);
    }


    private void SetStatesOfObjects(GameObject objectThatShouldBeActive, bool is2DRendering = false)
    {


        // for testing
        if (Testing == true)
        {
            SetPositionAndRotation(transform);
        }

        //Only update if necessary to avoid constant updates
        if (objectThatShouldBeActive.activeInHierarchy == false)
        {
            DeactivateAllObjects();


            objectThatShouldBeActive.SetActive(true);         
        }
        else if (is2DRendering)
        {
            //rotate object to face camera
            transform.LookAt(transform.position + aRCamera.transform.rotation * Vector3.forward, aRCamera.transform.rotation * Vector3.up);
        }
    }

}
