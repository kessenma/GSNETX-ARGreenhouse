using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System;
using System.Collections;
using TMPro;

public class ImageRecognitionManager : MonoBehaviour
{
    // Variables
    private ARTrackedImageManager _arTrackedImageManager;
    //transforms for all zone origin points in world space

    public CompletedZones completedZones;

    public ZoneOrigins zoneOrigins;

    public ZoneVariable activeZone;

    public GameEvent zoneImageTracked;

    public GameEvent zoneAlreadyLoaded;

    private bool imageRecognitionActive = false;
    private Camera arCamera;

    public void Start()
    {
        arCamera = FindObjectOfType<Camera>();
    }

    /// <summary>
    /// Responds to the activateImageRecognition event
    /// </summary>
    public void ActivateImageRecognition()
    {
        imageRecognitionActive = true;
    }

    /// <summary>
    /// Responds to the deactivateImageRecognition event by deactivating 
    /// </summary>
    public void DeactivateImageRecognition()
    {
        imageRecognitionActive = false;
    }

    // Init Method
    private void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    // When MonoBehaviour is enabled
    public void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    //When MonoBehaviour is disabled
    public void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    // Event listener for all image state changes
    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        if (imageRecognitionActive)
        {
            // When images are tracked for the very first time
            HandleImageRecognition(args.added);

            // When images are tracked subsequent times
            HandleImageRecognition(args.updated);
        }
    }

    private void HandleImageRecognition(List<ARTrackedImage> trackedImages)
    {
        foreach (ARTrackedImage trackedImage in trackedImages)
        {
            if (!completedZones.IsZoneAlreadyCompleted(ZoneVariable.GetZoneName(trackedImage.referenceImage.name)))
            {
                activeZone.Value = ZoneVariable.GetZoneName(trackedImage.referenceImage.name);
                //set the transform for the proper zone based on the scanned image's location
                zoneOrigins.Dictionary[activeZone.Value] = trackedImage.transform;
                Debug.Log($"T- TrackedImage.transform when scanned; position: {trackedImage.transform.position}, Rotation: {trackedImage.transform.rotation.eulerAngles}");
                Debug.Log($"T- TrackedImage.transform when scanned; Forward: {trackedImage.transform.forward}, Up: {trackedImage.transform.up}");
                Debug.Log($"T- arCamera.transform when scanned; Forward: {arCamera.transform.forward}, Up: {arCamera.transform.up}");
                Debug.Log($"T- arCamera.transform when scanned; position: {arCamera.transform.position}, Rotation: {arCamera.transform.rotation.eulerAngles}");

            }
            else
            {
                zoneAlreadyLoaded.Raise();
            }

        }
    }

}
