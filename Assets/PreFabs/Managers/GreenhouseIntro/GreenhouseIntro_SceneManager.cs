using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GreenhouseIntro_SceneManager : MonoBehaviour
{
    public GreenhouseIntro_Scene scene;

    //Intro Scene
    public GameObject introText;
    public TMP_Text introTextTest;
    public GameObject introImage;

    //Tab labels
    public TextMeshProUGUI growingOutsideLabel;
    public TextMeshProUGUI growingGreenhouseLabel;
    public TextMeshProUGUI growingSmartGreenhouseLabel;
    public TextMeshProUGUI soilLabel;
    public TextMeshProUGUI hydroponicsLabel;
    public TextMeshProUGUI aquaponicsLabel;

    //Tab body titles
    public GameObject growingOutsideTitle;
    public GameObject growingGreenhouseTitle;
    public GameObject growingSmartGreenhouseTitle;
    public TextMeshProUGUI soilTitle_TMP;
    public TextMeshProUGUI hydroponicsTitle_TMP;
    public TextMeshProUGUI aquaponicsTitle_TMP;

    //Tab bodies
    public GameObject growingOutsideBody;
    public GameObject growingGreenhouseBody;
    public GameObject growingSmartGreenhouseBody;
    public TextMeshProUGUI soilBody_TMP;
    public TextMeshProUGUI hydroponicsBody_TMP;
    public TextMeshProUGUI aquaponicsBody_TMP;
    public GameObject growingOutsideBenefits;
    public GameObject growingGreenhouseBenefits;
    public GameObject growingSmartGreenhouseBenefits;
    public TextMeshProUGUI soilBenefits_TMP;
    public TextMeshProUGUI hydroponicsBenefits_TMP;
    public TextMeshProUGUI aquaponicsBenefits_TMP;

    //Tab Images
    public Image growingOutsideImg;
    public Image growingGreenhouseImg;
    public Image growingSmartGreenhouseImg;
    public Image soilImg;
    public Image hydroponicsImg;
    public Image aquaponicsImg;

    //Planting Styles Page 1
    public TextMeshProUGUI remiQuestionText_TMP;
    public TextMeshProUGUI answerText_TMP;
    public GameObject smartGrowingImg;

    //Phase1 Scene
    public GameObject phase1Text;
    public GameObject phase1Image2;
    public GameObject phase1Image3;

    //Phase2 Scene
    public GameObject phase2Text;


    //Phase3 Scene
    public TextMeshProUGUI phase3Text_TMP;

    // Start is called before the first frame update
    void Start()
    {

        //There are two different ways to set a TextMeshPro Text object, here are both ways
        //For the bulk of this code the GetComponent strategy is used
        introText.GetComponent<TextMeshProUGUI>().text = scene.introPage.welcomeText;
        introTextTest.text = scene.introPage.welcomeText;

        introImage.GetComponent<Image>().sprite = scene.introPage.welcomeImage;

        //Growing Outside Tab
        growingOutsideLabel.text = scene.tabPage.tab1.label;
        growingOutsideImg.sprite = scene.tabPage.tab1.img;
        growingOutsideTitle.GetComponent<TextMeshProUGUI>().text = scene.tabPage.tab1.bodyTitle;
        growingOutsideBody.GetComponent<TextMeshProUGUI>().text = scene.tabPage.tab1.bodyText;
        growingOutsideBenefits.GetComponent<TextMeshProUGUI>().text = "" + scene.tabPage.tab1.benefitsText + "\n  • " + scene.tabPage.tab1.benefit1 + "\n  • " + scene.tabPage.tab1.benefit2;


        //growing in a greenhouse tab
        growingGreenhouseLabel.text = scene.tabPage.tab2.label;
        growingGreenhouseImg.sprite = scene.tabPage.tab2.img;
        growingGreenhouseTitle.GetComponent<TextMeshProUGUI>().text = scene.tabPage.tab2.bodyTitle;
        growingGreenhouseBody.GetComponent<TextMeshProUGUI>().text = scene.tabPage.tab2.bodyText;
        growingGreenhouseBenefits.GetComponent<TextMeshProUGUI>().text = "" + scene.tabPage.tab2.benefitsText + "\n  • " + scene.tabPage.tab2.benefit1 + "\n  • " + scene.tabPage.tab2.benefit2;

        //Growing smart greenhouse tab
        growingSmartGreenhouseLabel.text = scene.tabPage.tab3.label;
        growingSmartGreenhouseImg.sprite = scene.tabPage.tab3.img;
        growingSmartGreenhouseTitle.GetComponent<TextMeshProUGUI>().text = scene.tabPage.tab3.bodyTitle;
        growingSmartGreenhouseBody.GetComponent<TextMeshProUGUI>().text = scene.tabPage.tab3.bodyText;
        growingSmartGreenhouseBenefits.GetComponent<TextMeshProUGUI>().text = "" + scene.tabPage.tab3.benefitsText + "\n  • " + scene.tabPage.tab3.benefit1 + "\n  • " + scene.tabPage.tab3.benefit2;

        // planting style page 1
        remiQuestionText_TMP.text = scene.plantingStylesPage1.remiQuestionText;
        answerText_TMP.text = scene.plantingStylesPage1.answerText;
        smartGrowingImg.GetComponent<Image>().sprite = scene.plantingStylesPage1.smartGrowingImage;

        // soil tab
        soilLabel.text = scene.farmingStyles.tab1.label;
        soilImg.sprite = scene.farmingStyles.tab1.img;
        soilTitle_TMP.text = scene.farmingStyles.tab1.bodyTitle;
        soilBody_TMP.text = scene.farmingStyles.tab1.bodyText;
        soilBenefits_TMP.text = "" + scene.farmingStyles.tab1.benefitsText + "\n  • " + scene.farmingStyles.tab1.benefit1 + "\n  • " + scene.farmingStyles.tab1.benefit2;

        // hydroponics tab
        hydroponicsLabel.text = scene.farmingStyles.tab2.label;
        hydroponicsImg.sprite = scene.farmingStyles.tab2.img;
        hydroponicsTitle_TMP.text = scene.farmingStyles.tab2.bodyTitle;
        hydroponicsBody_TMP.text = scene.farmingStyles.tab2.bodyText;
        hydroponicsBenefits_TMP.text = "" + scene.farmingStyles.tab2.benefitsText + "\n  • " + scene.farmingStyles.tab2.benefit1 + "\n  • " + scene.farmingStyles.tab2.benefit2;

        // aquaponics tab
        aquaponicsLabel.text = scene.farmingStyles.tab3.label;
        aquaponicsImg.sprite = scene.farmingStyles.tab3.img;
        aquaponicsTitle_TMP.text = scene.farmingStyles.tab3.bodyTitle;
        aquaponicsBody_TMP.text = scene.farmingStyles.tab3.bodyText;
        aquaponicsBenefits_TMP.text = "" + scene.farmingStyles.tab3.benefitsText + "\n  • " + scene.farmingStyles.tab3.benefit1 + "\n  • " + scene.farmingStyles.tab3.benefit2;

        // phase 1
        phase1Text.GetComponent<TextMeshProUGUI>().text = scene.phase1Page.phase1Text;        
        phase1Image2.GetComponent<SpriteRenderer>().sprite = scene.phase1Page.phase1Image2;
        phase1Image3.GetComponent<SpriteRenderer>().sprite = scene.phase1Page.phase1Image3;

        // phase 2
        phase2Text.GetComponent<TextMeshProUGUI>().text = scene.phase2Page.phase2Text;        
        
        // phase 3
        phase3Text_TMP.text = scene.phase3Page.phase3Text;        
    }


}
