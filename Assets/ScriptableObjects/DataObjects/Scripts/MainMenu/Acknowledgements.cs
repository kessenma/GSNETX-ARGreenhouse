using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scenes/MainMenu/Acknowledgements", fileName = "Acknowledgements")]
public class Acknowledgements : ScriptableObject
{
    // Acknowledgemnts
    public string clickCompanies;
    public string clickNames;
    public string clickWebsites;

    // Companies
    public string companyTitle;

    // Names
    public string namesTitle;


    // Websites
    public string websitesTitle;

    // Lists
    public List<string> websites;
    public List<string> names;
}
