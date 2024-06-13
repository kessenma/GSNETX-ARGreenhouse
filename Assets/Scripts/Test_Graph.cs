using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Graph : MonoBehaviour
{
    [SerializeField] private Sprite primaryCircleSprite;
    [SerializeField] private Sprite secondaryCircleSprite;
    //[SerializeField] private Animation circleAnimation;

    private RectTransform graph_Container_02;
    public Font myFont;


    private void Awake()
    {
        graph_Container_02 = transform.Find("Graph_Container_02").GetComponent<RectTransform>();

        //pop
        List<float> popList = new List<float>();

        float[] popArray = new float[] { 21.7f, 23.8f, 26.1f, 28.3f, 30.5f, 32.7f,
                                        34.9f, 37.1f, 39.3f, 41.5f, 43.7f};
        popList.AddRange(popArray);

        //cropland
        List<float> croplandList = new List<float>();

        float[] croplandArray = new float[] { 38.7f, 33.7f, 29.1f, 29.4f, 24.6f, 21.4f,
                                                18.1f, 14.9f, 11.6f, 8.4f, 5.2f};
        croplandList.AddRange(croplandArray);


        //#IF !UNITY_EDITOR
        //Debug.Log(datesList);
        //#endif

        ShowGraph(popList, true);

        ShowGraph(croplandList, false);
    }

    private void CreateDataPoint(Vector2 anchoredPosition, Sprite circleSprite)
    {
        GameObject dataPoint = new GameObject("dataPoint", typeof(Image));

        dataPoint.transform.SetParent(graph_Container_02, false);

        dataPoint.GetComponent<Image>().sprite = circleSprite;

        RectTransform rectTransform = dataPoint.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(50, 50);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

    }

    private void ShowGraph(List<float> valueList, bool primaryData)
    {
        float graphHeight = graph_Container_02.sizeDelta.y;

        // set distance between each x value
        float xSize = 175f;

        float yMaximum = 40f;

        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = 100 + (i * xSize);

            float textYPosition = graphHeight - (graphHeight - 10);

            float yPosition = 50 + (valueList[i] / yMaximum) * graphHeight;

            GameObject xAxisLabels = new GameObject("xAxisLabels", typeof(Text));
            xAxisLabels.transform.SetParent(graph_Container_02, false);

            Text xAxisLabelsText = xAxisLabels.GetComponent<Text>();

            xAxisLabelsText.text = "testText";

            xAxisLabelsText.font = myFont;

            xAxisLabelsText.fontSize = 24;


            RectTransform xAxisLabelsRectTransform = xAxisLabels.GetComponent<RectTransform>();
            xAxisLabelsRectTransform.sizeDelta = new Vector2(100, 50);
            xAxisLabelsRectTransform.anchoredPosition = new Vector2(xPosition, textYPosition);
            xAxisLabelsRectTransform.anchorMin = new Vector2(0, 0);
            xAxisLabelsRectTransform.anchorMax = new Vector2(0, 0);

            if (primaryData)
            {
                CreateDataPoint(new Vector2(xPosition, yPosition), primaryCircleSprite);

            }
            else
            {
                CreateDataPoint(new Vector2(xPosition, yPosition), secondaryCircleSprite);
                
            }

        }

    }

    /*private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject dotConnection = new GameObject("dotConnection", typeof(Image));
        dotConnection.transform.SetParent(graph_Container_02, false);

        dotConnection.GetComponent<Image>().color = new Color(1,1,1, .5f);
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);



        RectTransform rectTransform = dotConnection.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        //rectTransform.localEulerAngles = new Vector3(0,0,)

    }*/
}
