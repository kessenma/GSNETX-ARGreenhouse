using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class PopulationVsLandUseDocument
{
    public string year;
    public string date_desc;
    public string pop;
    public string state_name;
    public string total_cropland_acres;
}

[Serializable]
 public class PopulationVsLandUseDocumentList
 {
     public List<PopulationVsLandUseDocument> list;

 }