using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Websites_Actor : MonoBehaviour
{
    public Acknowledgements acknowledgements;
    public GameObject websitesPanel;
    public GameObject acknowledgementsPanel;
    public TMP_Text websitesTitle_TMP;
    public TMP_Text websitesFirstHalf_TMP;
    public TMP_Text websitesSecondHalf_TMP;

    /// <summary>
    /// assign all text mesh pros to the appropriate text
    /// </summary>
    public void Start()
    {
        // Websites
        websitesTitle_TMP.text = acknowledgements.websitesTitle;

        var firstHalfWebsites = acknowledgements.websites.Take(acknowledgements.websites.Count / 2);
        websitesFirstHalf_TMP.text = firstHalfWebsites.Aggregate("", (acc, website) => acc + website + "\n\n");

        var secondHalfWebsites = acknowledgements.websites.Skip(acknowledgements.websites.Count / 2);
        websitesSecondHalf_TMP.text = secondHalfWebsites.Aggregate("", (acc, website) => acc + website + "\n\n");
    }

    /// <summary>
    /// Opens up the page to display the websites
    /// </summary>
    public void openWebsitesPage()
    {
        websitesPanel.SetActive(true);
    }
}
