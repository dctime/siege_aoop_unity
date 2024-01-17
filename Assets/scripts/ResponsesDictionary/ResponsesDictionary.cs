using UnityEngine;
using System;
using System.Collections.Generic;

class ResponsesDictionary : MonoBehaviour
{
    [SerializeField]
    public Dictionary<string, Response> responsesDictionary;

    public void Start()
    {
        responsesDictionary = new Dictionary<string, Response>();
    }

    public void AddResponse(string key, Response value)
    {
        responsesDictionary.Add(key, value);
    }
}