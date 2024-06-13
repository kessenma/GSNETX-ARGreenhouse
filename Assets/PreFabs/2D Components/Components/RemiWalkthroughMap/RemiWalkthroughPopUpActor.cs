using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemiWalkthroughPopUpActor : MonoBehaviour
{
    public GameObject remiPopUp;
    public GameObject walkthroughPanel;
    public GameObject buttonBlocker;
    public GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        buttonBlocker.SetActive(true);
        nextButton.GetComponent<Button>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenRemiPopUp()
    {
        walkthroughPanel.SetActive(false);
        remiPopUp.SetActive(true);
        buttonBlocker.SetActive(false);
        nextButton.GetComponent<Button>().enabled = true;
    }
}
