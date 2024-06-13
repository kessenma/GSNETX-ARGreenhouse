using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARTestingButtonActor : MonoBehaviour
{

    public VirtualObjectBase virtualObjectToMock;
    public GameObject virtualObjectPrefab;
    private VirtualObjectActor actor;

    public void Start()
    {
        Debug.Log("Sean/Tyler - Start Method of ARTestingButton ");

        var virtualObject = Instantiate(virtualObjectPrefab, transform, false);
        actor = virtualObject.GetComponent<VirtualObjectActor>();
        //actor.Init(virtualObjectToMock.name, virtualObjectToMock);
        Debug.Log("Sean/Tyler - Start Method of ARTestingButton, Actor after: " + actor);
    }

    public void MockObjectFound()
    {
        Debug.Log("Sean/Tyler - MockObjectFound called, Actor: " + actor);
        actor.ShowGreenhouseItem();
        actor.TriggerFoundSignals();

    }

    public void HidePopup()
    {
        Debug.Log("Sean/Tyler - Enter HidePopup, Actor: " + actor);
        actor.HidePopup();
    }


}
