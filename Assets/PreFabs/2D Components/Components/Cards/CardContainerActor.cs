using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardContainerActor : MonoBehaviour
{
    public VerticalIcon_Card card;

    public TextMeshProUGUI cardTitle;
    public TextMeshProUGUI cardListItemTitle1;
    public TextMeshProUGUI cardListItemBody1;
    public TextMeshProUGUI cardListItemTitle2;
    public TextMeshProUGUI cardListItemBody2;
    public PopUpStatus popUpStatus;

    // Start is called before the first frame update
    void Start()
    {
        cardTitle.text = card.cardTitle;
        cardListItemTitle1.text = card.cardListItemTitle1;
        cardListItemBody1.text = card.cardListItemBody1;
        cardListItemTitle2.text = card.cardListItemTitle2;
        cardListItemBody2.text = card.cardListItemBody2;
    }

    public void ClosePopUp()
    {
        gameObject.SetActive(false);
        popUpStatus.PopUpDespawned();
    }

}
