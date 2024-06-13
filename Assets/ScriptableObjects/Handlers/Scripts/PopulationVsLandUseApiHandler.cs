using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Handlers/PopulationVsLandUseApiHandler", fileName = "PopulationVsLandUseApiHandler")]
public class PopulationVsLandUseApiHandler : ApiHandler
{
    public string baseUrl;
    public string functionName;
    public string useCaseName;
    public DataCache cache;
    public StringVariable bearerToken;

    public void GetData()
    {
        string jsonResponse = Get(
            String.Format(
                "{0}{1}?code={2}&useCase={3}",
                baseUrl, 
                functionName,
                bearerToken.Value,
                useCaseName
            )
        );

        PopulationVsLandUseDocumentList result = JsonUtility.FromJson<PopulationVsLandUseDocumentList>("{\"list\":" + jsonResponse + "}");
        foreach (PopulationVsLandUseDocument doc in result.list)
        {
            cache.Add(doc.year, doc);
        }

        // --------------------------------------

        foreach( KeyValuePair<string, object> kvp in cache.cache )
        {
            Debug.Log(String.Format("Key = {0}", kvp.Key));
            if (kvp.Value is IList<object>)
            {
                foreach( var doc in (IList<object>)kvp.Value )
                {
                    Debug.Log(
                        "Document: "
                        +((PopulationVsLandUseDocument)doc).year
                        +" "
                        +((PopulationVsLandUseDocument)doc).pop
                        +" "
                        +((PopulationVsLandUseDocument)doc).state_name
                        +" "
                        +((PopulationVsLandUseDocument)doc).total_cropland_acres
                    );
                }
            }
            else
            {
                PopulationVsLandUseDocument doc = (PopulationVsLandUseDocument)kvp.Value;
                Debug.Log("Document: "+doc.year+" "+doc.pop+" "+doc.state_name+" "+doc.total_cropland_acres);
            }
        }
    }
}