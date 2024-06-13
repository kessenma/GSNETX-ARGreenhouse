using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Companies_Actor : MonoBehaviour
{
    public Acknowledgements acknowledgements;
    public GameObject companiesPanel;
    public GameObject acknowledgementsPanel;
    public TMP_Text companiesTitle_TMP;

    /// <summary>
    /// assign all text mesh pros to the appropriate text
    /// </summary>
    public void Start()
    {
        // Names
        companiesTitle_TMP.text = acknowledgements.companyTitle;
    }

    /// <summary>
    /// Opens up the page to display the companies
    /// </summary>
    public void openCompaniesPage()
    {
        companiesPanel.SetActive(true);
    }
}
