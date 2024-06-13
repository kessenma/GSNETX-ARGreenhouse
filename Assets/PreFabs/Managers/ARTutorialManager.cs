using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ARTutorialManager : MonoBehaviour
{
    public List<GameObject> panels;
    public GameObject notFoundObject;
    public GameObject foundObject;
    public GameObject popUpCard;
    public GameObject likeButton;
    public GameObject navigationPanel;
    public GameObject sideBar;
    public GameObject zoneLoadedPanel;
    public GameObject filledHeart;
    public GameObject tutorial2DObjectContainer;
    public GameEvent enableNextButton;
    public GameEvent disableNextButton;
    public GameEvent goToPreviousScene;
    public GameEvent enableDeviceOrientationPanel;
    public GameEvent disableDeviceOrientationPanel;
    public GameEvent enableZoneChange;
    public GameEvent disableZoneChange;
    public GameEvent minimizeSidebar;
    public ARTutorial remiText;
    public TextMeshProUGUI panel1;
    public TextMeshProUGUI panel2;
    public TextMeshProUGUI panel4;
    public TextMeshProUGUI panel5;
    public TextMeshProUGUI panel6;
    public TextMeshProUGUI panel7;
    public TextMeshProUGUI panel8;
    public TextMeshProUGUI panel9;
    public TextMeshProUGUI panel11;
    public TextMeshProUGUI panel12;
    public TextMeshProUGUI panel13;
    public TextMeshProUGUI panel14;
    public TextMeshProUGUI panel15;
    public TextMeshProUGUI panel16;
    public CompletedZones userCompletedZones;

    private int activePanelIndex = -1;
    private bool zoneLoaded = false;
    private Camera arCamera;

    public void Start()
    {
        arCamera = FindObjectOfType<Camera>();// always find the camera
    }

    private void Awake()
    {
        if (!userCompletedZones.hasUserCompletedTutorial())
        {
            // Set all panels to inactive
            for (int i = 0; i < panels.Count; i++)
            {
                panels[i].SetActive(false);
            }
            // Set the first panel to active
            activePanelIndex = 0;
            SetSpecialObjectStatus();
            panels[activePanelIndex].SetActive(true);
            
        }
        else
        {
            //disable tutorial
            enableNextButton.Raise();
            gameObject.SetActive(false);
        }
        


        //Set all of the text boxes
        panel1.text = remiText.remiPanel1;
        panel2.text = remiText.remiPanel2;
        panel4.text = remiText.remiPanel4;
        panel5.text = remiText.remiPanel5;
        panel6.text = remiText.remiPanel6;
        panel7.text = remiText.remiPanel7;
        panel8.text = remiText.remiPanel8;
        panel9.text = remiText.remiPanel9;
        panel11.text = remiText.remiPanel11;
        panel12.text = remiText.remiPanel12;
        panel13.text = remiText.remiPanel13;
        panel14.text = remiText.remiPanel14;
        panel15.text = remiText.remiPanel15;
        panel16.text = remiText.remiPanel16;
    }

    /// <summary>
    /// Progresses to the next panel
    /// </summary>
    public void GoToNextPanel()
    {
        if(!(activePanelIndex == panels.Count - 1))
        {
            panels[activePanelIndex].SetActive(false);
            activePanelIndex++;
            panels[activePanelIndex].SetActive(true);
            SetSpecialObjectStatus();
        }
        else // Deactivate all tutorial objects, tutorial is now over
        {
            panels[activePanelIndex].SetActive(false);
            notFoundObject.SetActive(false);
            foundObject.SetActive(false);
            navigationPanel.SetActive(false);
            userCompletedZones.SetUserCompletedTutorialToTrue();
            //enableZoneChange.Raise();
        }
    }

    /// <summary>
    /// Retreats to the previous panel
    /// </summary>
    public void GoToPreviousPanel()
    {
        if (activePanelIndex == 0)
        {
            goToPreviousScene.Raise();
        }
        else
        {
            panels[activePanelIndex].SetActive(false);
            activePanelIndex--;
            panels[activePanelIndex].SetActive(true);
            SetSpecialObjectStatus();
        }
    }

    private void SetSpecialObjectStatus()
    {
        enableNextButton.Raise();
        switch (activePanelIndex)
        {
            case 0:
                disableDeviceOrientationPanel.Raise();
                notFoundObject.SetActive(false);
                foundObject.SetActive(false);
                popUpCard.SetActive(false);
                sideBar.SetActive(false);
                zoneLoadedPanel.SetActive(false);
                break;
            case 1:
                notFoundObject.SetActive(false);
                break;
            case 2:
                disableNextButton.Raise();
                popUpCard.SetActive(false);
                foundObject.SetActive(false);
                notFoundObject.SetActive(true);
                break;
            case 3:
                notFoundObject.SetActive(false);
                foundObject.SetActive(true);
                popUpCard.SetActive(true);
                likeButton.SetActive(false);
                filledHeart.SetActive(false);
                break;
            case 4:
                disableNextButton.Raise();
                likeButton.SetActive(true);
                popUpCard.SetActive(true);
                break;
            case 5:
                popUpCard.SetActive(true);
                disableNextButton.Raise();
                break;
            case 6:
                foundObject.SetActive(true);
                notFoundObject.SetActive(false);
                popUpCard.SetActive(false);
                break;
            case 7:
                foundObject.SetActive(false);
                notFoundObject.SetActive(true);
                sideBar.SetActive(false);
                break;
            case 8:
                notFoundObject.SetActive(false);
                sideBar.SetActive(true);
                panels[activePanelIndex].SetActive(true);
                disableNextButton.Raise();
                break;
            case 10:
                zoneLoadedPanel.SetActive(false);
                disableDeviceOrientationPanel.Raise();
                disableZoneChange.Raise();
                minimizeSidebar.Raise();
                break;
            case 11:
                minimizeSidebar.Raise();
                if (!zoneLoaded)
                {
                    disableNextButton.Raise();
                    enableDeviceOrientationPanel.Raise();
                    enableZoneChange.Raise();
                }
                else {
                    zoneLoadedPanel.SetActive(true);
                }
                break;
            case 12:
                minimizeSidebar.Raise();
                zoneLoadedPanel.SetActive(false);
                disableDeviceOrientationPanel.Raise();
                disableZoneChange.Raise();
                break;
            default: break;
        }
    }

    public void SpawnNotFoundObject()
    {
        // temp code t handle passing vy value rather than pass by reference issue
        Vector3 temp = arCamera.transform.position;
        temp.z = temp.z + 1;
        notFoundObject.transform.position = temp;
        notFoundObject.SetActive(true);
    }

    public void SpawnFoundObject()
    {

        foundObject.transform.position = notFoundObject.transform.position;
        foundObject.SetActive(true);
    }

    /// <summary>
    /// Closes the pop-up card and enables the next button
    /// </summary>
    public void ClosePopUpCard()
    {
        if (activePanelIndex == 5)
        {
            popUpCard.SetActive(false);
            //enableNextButton.Raise();
            GoToNextPanel();
        }
    }

    /// <summary>
    /// ObjectTapped event response, goes to the next panel if we are on the 3rd panel
    /// </summary>
    public void ObjectTapped()
    {
        if(activePanelIndex == 2)
        {
            GoToNextPanel();
        }
    }

    /// <summary>
    /// ToggleSideBar event response, enables the next button if we are on the 10th panel
    /// </summary>
    public void ToggleSideBar()
    {
        if(activePanelIndex == 8)
        {
            //enableNextButton.Raise();
            GoToNextPanel();
        }
    }

    /// <summary>
    /// NewZoneLoaded event response, goes to the next panel if we are on the 13th panel
    /// </summary>
    public void NewZoneLoaded()
    {
        zoneLoaded = true;
        if(activePanelIndex == 11)
        {
            GoToNextPanel();
        }
    }

    /// <summary>
    /// Hides the tutorial 2d elements
    /// </summary>
    public void HideTutorial()
    {
        tutorial2DObjectContainer.SetActive(false);
    }

    /// <summary>
    /// Shows the tutorial 2d elements
    /// </summary>
    public void ShowTutorial()
    {
        tutorial2DObjectContainer.SetActive(true);
    }
   
}
