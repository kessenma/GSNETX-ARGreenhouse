using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using UnityEngine;

public class ApiHandler  : ScriptableObject
{
    protected string Get(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        return reader.ReadToEnd();
    }
}