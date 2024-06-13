using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearNotFoundTouch : MonoBehaviour
{
    public GameEvent objectTapped;
    private Camera aRCamera;

    /// <summary>
    /// Find the ar camera
    /// </summary>
    public void Start()
    {
        aRCamera = FindObjectOfType<Camera>();
    }

    /// <summary>
    /// Checks if the object has been touched
    /// </summary>
    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray raycast = aRCamera.ScreenPointToRay(touch.position);
                if (Physics.Raycast(raycast, out RaycastHit raycastHit))
                {
                    if (GameObject.ReferenceEquals(raycastHit.collider.gameObject, gameObject))
                    {
                        objectTapped.Raise();
                    }
                }
            }
        }
    }
}