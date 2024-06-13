using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Acknowledgements_Actor : MonoBehaviour
{
    public Acknowledgements acknowledgements;
    public TMP_Text clickCompanies_TMP;
    public TMP_Text clickNames_TMP;
    public TMP_Text clickWebsites_TMP;
    public GameObject companiesPanel;
    public GameObject namesPanel;
    public GameObject websitesPanel;
    public GameObject acknowledgementsPanel;

    /// <summary>
    /// assign all text mesh pros to the appropriate text
    /// </summary>
    public void Start()
    {
        clickCompanies_TMP.text = acknowledgements.clickCompanies;
        clickNames_TMP.text = acknowledgements.clickNames;
        clickWebsites_TMP.text = acknowledgements.clickWebsites;
    }

    /// <summary>
    /// Opens up the page to display the companies
    /// </summary>
    public void returnToAcknowledgementsPage()
    {
        companiesPanel.SetActive(false);
        namesPanel.SetActive(false);
        websitesPanel.SetActive(false);
        acknowledgementsPanel.SetActive(true);
    }

    /// <summary>
    /// Close acknowledgements pop-up
    /// </summary>
    public void exitAcknowledgementsPage()
    {
        acknowledgementsPanel.SetActive(false);
    }
}
