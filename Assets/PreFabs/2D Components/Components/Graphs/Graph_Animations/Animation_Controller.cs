using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Animation_Controller : MonoBehaviour
{
    public GameObject graph_Container_02;

    public Slider slider;

    public List<GameObject> dataPointContainers;

    List<Animator> dataPointContainerAnimators = new List<Animator>();

    private void Start()
    {
        foreach (GameObject dataPointContainer in dataPointContainers)
        {
            Animator dataPointContainerAnimator = dataPointContainer.GetComponent<Animator>();

            dataPointContainerAnimators.Add(dataPointContainerAnimator);
        }

    }

    // <summary>
    // Listens for Pointer Up event trigger to be raised by slider.
    // Calls AnimateDataPoints() and passes in the slider value.
    // </summary>
    public void OnEndDrag()
    {
        float sliderValue = slider.value;
        AnimateDataPoints(sliderValue);
    }

    // <summary>
    // Called by OnEndDrag().
    // Triggers animations on the appropriate dataPointContainers according to the slider value.
    // </summary>
    public void AnimateDataPoints(float dataPointNumber)
    {

        int dataPointContainerIndex = 0;
        int dataPointNumberInt = (int)dataPointNumber;

        foreach (GameObject dataPointContainer in dataPointContainers)
        {
            CanvasGroup canvasGroup = dataPointContainer.GetComponent<CanvasGroup>();
            Animator dataPointContainerAnimator = dataPointContainer.GetComponent<Animator>();

            if (dataPointContainerIndex < dataPointNumberInt && canvasGroup.alpha != 1)
            {
                dataPointContainerAnimator.SetTrigger("FadeIn_Animation_01");
            }
            else if (dataPointContainerIndex >= dataPointNumberInt && canvasGroup.alpha != 0)
            {
                dataPointContainerAnimator.SetTrigger("Invisible");
            }

            ++dataPointContainerIndex;
        }
    }

}
