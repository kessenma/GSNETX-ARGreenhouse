using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;


[CreateAssetMenu(menuName = "Generic/LikingSystem", fileName = "LikingSystem")]
public class LikingSystem : ScriptableObject
{
    private enum categories
    {
        sciPoints,
        engMathPoints,
        techPoints,
        leadPoints
    }
    public int[] points = new int[] { 0, 0, 0, 0 };
    private List<String> likedObjects = new List<String>();

    public string sciTitle, techTitle, engMathTitle, leadTitle;
    public List<String> sciCareers;
    public List<String> techCareers;
    public List<String> engMathCareers;
    public List<String> leadCareers;

    /* Methods for the likButtonActor to modify data */

    /// <summary>
    /// Adds the name of an item to the liked items list
    /// </summary>
    /// <param name="name">name of the item to be added</param>
    public void AddLikedItemName(string name)
    {
        likedObjects.Add(name);
    }

    /// <summary>
    /// Removes the name of an item from the liked items list
    /// </summary>
    /// <param name="name">name of the item to be removed</param>
    public void RemovedLikedItemName(string name)
    {
        likedObjects.Remove(name);
    }

    /// <summary>
    /// Modifies the amount of sciene points by the amount given
    /// </summary>
    /// <param name="amount">amount of the points to add/remove</param>
    public void ModifySciPoint(int amount)
    {
        points[(int)categories.sciPoints] = points[(int)categories.sciPoints] + amount;
    }

    /// <summary>
    /// Modifies the amount of engineering/math points by the amount given
    /// </summary>
    /// <param name="amount">amount of the points to add/remove</param>
    public void ModifyEngMathPoint(int amount)
    {
        points[(int)categories.engMathPoints] = points[(int)categories.engMathPoints] + amount;
    }

    /// <summary>
    /// Modifies the amount of technology points by the amount given
    /// </summary>
    /// <param name="amount">amount of the points to add/remove</param>
    public void ModifyTechPoint(int amount)
    {
        points[(int)categories.techPoints] = points[(int)categories.techPoints] + amount;
    }

    /// <summary>
    /// Modifies the amount of leadership points by the amount given
    /// </summary>
    /// <param name="amount">amount of the points to add/remove</param>
    public void ModifyLeadPoint(int amount)
    {
        points[(int)categories.leadPoints] = points[(int)categories.leadPoints] + amount;
    }


    /* Methods for career scene manager to retrive end data */

    /// <summary>
    /// Determines if there is a category to recommend or not
    /// </summary>
    /// <returns> true/false </returns>
    public bool HasRecommendedCategory()
    {
        return (points[(int)categories.sciPoints] + points[(int)categories.engMathPoints] + points[(int)categories.techPoints] + points[(int)categories.leadPoints]) != 0;
    }

    /// <summary>
    /// Returns text for remi to introduce liked objects
    /// </summary>
    /// <returns> text for remi to introduce liked objects </returns>
    public string GetRemiLikedObjectsText()
    {
        return "Here are some of the objects you have liked along the way...";
    }

    /// <summary>
    /// Returns text for remi to introduce recommended career category
    /// </summary>
    /// <returns> text for remi to introduce recommended career category </returns>
    public string GetRemiCareerCategoryText()
    {
        return String.Format("Based on the objects you have liked I think you would be interested in {0}! Be sure to look for these careers in the next sections.", GetCategoryTitle());
    }

    /// <summary>
    /// Returns the category title of the recommended category
    /// </summary>
    /// <returns> title of the recommended category</returns>
    public string GetCategoryTitle()
    {
        var recommenedCategory = (categories) points.ToList().IndexOf(points.Max());
        switch (recommenedCategory)
        {
            case categories.sciPoints:
                return sciTitle;
            
            case categories.techPoints:
                return techTitle;

            case categories.engMathPoints:
                return engMathTitle;
            
            default:
                return leadTitle;
        }
    }

    /// <summary>
    /// Returns the category body of the recommended category
    /// </summary>
    /// <returns> body of the recommended category</returns>
    public string GetCareerList()
    {
        var recommenedCategory = (categories)points.ToList().IndexOf(points.Max());
        switch (recommenedCategory)
        {
            case categories.sciPoints:
                return FormatCareers(sciCareers);

            case categories.techPoints:
                return FormatCareers(techCareers);

            case categories.engMathPoints:
                return FormatCareers(engMathCareers);

            default:
                return FormatCareers(leadCareers);
        }
    }

    /// <summary>
    /// Returns the list of liked objects of the recommended category
    /// </summary>
    /// <returns> the list of liked objects in a string </returns>
    public string GetLikedObjects()
    {
        return String.Join("\n", likedObjects);
    }

    /// <summary>
    /// Resets the state of the liking system back to no liked objects
    /// </summary>
    public void Reset()
    {
        points = new int[] { 0, 0, 0, 0 };
        likedObjects = new List<String>();
    }

    /// <summary>
    /// Joins a list of careers into a string with two new lines between each career
    /// </summary>
    /// <param name="careers"> a list of careers to format </param>
    /// <returns> string of formatted careers </returns>
    public string FormatCareers(List<String> careers)
    {
        return String.Join("\n\n", careers);
    }
}
