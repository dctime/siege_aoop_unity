using UnityEngine;
using System;
using System.Collections.Generic;
using static AbstractResponse;

// namespace ResponsesDictionary
// {
// }
class ResponsesDictionary : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, AbstractResponse> responsesDictionary;
    [SerializeField]
    private AbstractResponse childResponse;
    public void Start()
    {
        responsesDictionary = new Dictionary<string, AbstractResponse>();
    }

    public void AddResponse(string key, AbstractResponse value)
    {
        responsesDictionary.Add(key, value);
    }
    public void CheckResponse(string response)
    {
        string[] splittedResponse = response.Split(' ');
        if (splittedResponse.Length != 2)
        {
            throw new Exception("Received message must contain 2 words id and response message");
        }
        string id = splittedResponse[0];
        string responseMessage = splittedResponse[1];
        Debug.Log($"{typeof(ResponsesDictionary)}: Received Message: id = {id} ; message = {responseMessage}");
        CallResponse(id, responseMessage);
    }
    
    public void CallResponse(string id, string responseMessage)
    {
        if (responsesDictionary.TryGetValue(id, out childResponse))
        {
            childResponse.ResponseToMessage(responseMessage);
        }
        else
        {
            throw new Exception($"{typeof(ResponsesDictionary)}: Key {id} not found in ResponsesDictionary");
        }
    }

}