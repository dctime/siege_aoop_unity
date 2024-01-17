using UnityEngine;
using System;
using System.Collections.Generic;

class PublisheridDictionary : MonoBehaviour
{
    public Dictionary<string, Guid> publisheridDictionary;

    public void Start()
    {
        publisheridDictionary = new Dictionary<string, Guid>();
    }

    public void addPublisherid(string publisheridName, Guid publisherid)
    {
        publisheridDictionary.Add(publisheridName, publisherid);
    }

    public bool checkInPublisheridDictionary(string publisheridName)
    {
        return publisheridDictionary.ContainsKey(publisheridName);
    }
}