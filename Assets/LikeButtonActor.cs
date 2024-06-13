using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeButtonActor : MonoBehaviour
{
    public LikingSystem likeData;
    public int sciencePoints;
    public int engineeringAndMathPoints;
    public int technologyPoints;
    public int leadershipPoints;
    public string attachedObjectName;
    public GameObject likedImage;

    private bool isLiked = false;

    private void Start()
    {
        likedImage.SetActive(false);
    }

    /// <summary>
    /// Flips the state of the button between liked and unliked
    /// </summary>
    public void ToggleLikeButton()
    {
        isLiked = !isLiked;
        
        if(isLiked)
        {
            ButtonLiked();
        }
        else
        {
            ButtonUnliked();
        }
    }

    /// <summary>
    /// Flips the state of the button but doesn't send data to the liking system
    /// </summary>
    public void FauxToggleLikeButton()
    {
        isLiked = !isLiked;

        if (isLiked)
        {
            FauxButtonLiked();
        }
        else
        {
            FauxButtonUnliked();
        }
    }

    private void ButtonLiked()
    {
        likedImage.SetActive(true);
        likeData.ModifySciPoint(sciencePoints);
        likeData.ModifyTechPoint(technologyPoints);
        likeData.ModifyLeadPoint(leadershipPoints);
        likeData.ModifyEngMathPoint(engineeringAndMathPoints);
        likeData.AddLikedItemName(attachedObjectName);
    }

    private void ButtonUnliked()
    {
        likedImage.SetActive(false);
        likeData.ModifySciPoint(-sciencePoints);
        likeData.ModifyTechPoint(-technologyPoints);
        likeData.ModifyLeadPoint(-leadershipPoints);
        likeData.ModifyEngMathPoint(-engineeringAndMathPoints);
        likeData.RemovedLikedItemName(attachedObjectName);
    }

    private void FauxButtonLiked()
    {
        likedImage.SetActive(true);
    }

    private void FauxButtonUnliked()
    {
        likedImage.SetActive(false);
    }
}
