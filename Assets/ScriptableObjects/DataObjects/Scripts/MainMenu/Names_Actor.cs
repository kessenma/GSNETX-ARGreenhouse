using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Names_Actor : MonoBehaviour
{
    public Acknowledgements acknowledgements;
    public GameObject namesPanel;
    public GameObject acknowledgementsPanel;
    public TMP_Text namesTitle_TMP;
    public TMP_Text name1_TMP;
    public TMP_Text name2_TMP;
    public TMP_Text name3_TMP;
    public TMP_Text name4_TMP;
    public TMP_Text name5_TMP;
    public TMP_Text name6_TMP;
    public TMP_Text name7_TMP;
    public TMP_Text name8_TMP;
    public TMP_Text name9_TMP;
    public TMP_Text name10_TMP;
    public TMP_Text name11_TMP;
    public TMP_Text name12_TMP;
    public TMP_Text name13_TMP;
    public TMP_Text name14_TMP;
    public TMP_Text name15_TMP;
    public TMP_Text name16_TMP;
    public TMP_Text name17_TMP;
    public TMP_Text name18_TMP;
    public TMP_Text name19_TMP;
    public TMP_Text name20_TMP;
    public TMP_Text name21_TMP;
    public TMP_Text name22_TMP;
    public TMP_Text name23_TMP;
    public TMP_Text name24_TMP;
    public TMP_Text name25_TMP;
    public TMP_Text name26_TMP;
    public TMP_Text name27_TMP;
    public TMP_Text name28_TMP;
    public TMP_Text name29_TMP;
    public TMP_Text name30_TMP;

    /// <summary>
    /// assign all text mesh pros to the appropriate text
    /// </summary>
    public void Start()
    {
        // Names
        namesTitle_TMP.text = acknowledgements.namesTitle;
        name1_TMP.text = acknowledgements.names[0];
        name2_TMP.text = acknowledgements.names[1];
        name3_TMP.text = acknowledgements.names[2];
        name4_TMP.text = acknowledgements.names[3];
        name5_TMP.text = acknowledgements.names[4];
        name6_TMP.text = acknowledgements.names[5];
        name7_TMP.text = acknowledgements.names[6];
        name8_TMP.text = acknowledgements.names[7];
        name9_TMP.text = acknowledgements.names[8];
        name10_TMP.text = acknowledgements.names[9];
        name11_TMP.text = acknowledgements.names[10];
        name12_TMP.text = acknowledgements.names[11];
        name13_TMP.text = acknowledgements.names[12];
        name14_TMP.text = acknowledgements.names[13];
        name15_TMP.text = acknowledgements.names[14];
        name16_TMP.text = acknowledgements.names[15];
        name17_TMP.text = acknowledgements.names[16];
        name18_TMP.text = acknowledgements.names[17];
        name19_TMP.text = acknowledgements.names[18];
        name20_TMP.text = acknowledgements.names[19];
        name21_TMP.text = acknowledgements.names[20];
        name22_TMP.text = acknowledgements.names[21];
        name23_TMP.text = acknowledgements.names[22];
        name24_TMP.text = acknowledgements.names[23];
        name25_TMP.text = acknowledgements.names[24];
        name26_TMP.text = acknowledgements.names[25];
        name27_TMP.text = acknowledgements.names[26];
        name28_TMP.text = acknowledgements.names[27];
        name29_TMP.text = acknowledgements.names[28];
        name30_TMP.text = acknowledgements.names[29];
    }

    /// <summary>
    /// Opens up the page to display the names
    /// </summary>
    public void openNamesPage()
    {
        namesPanel.SetActive(true);
    }
}
