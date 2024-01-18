using UnityEngine;
using System;
using System.Collections.Generic;
using static AbstractResponse;

public class ResponsesDictionary : MonoBehaviour
{
    private string id;
    private string responseMessage;
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
        else if (splittedResponse.Length == 2)
        {
            id = splittedResponse[0];
            responseMessage = splittedResponse[1];
            Debug.Log($"{typeof(ResponsesDictionary)}: Received Message: id = {id} ; message = {responseMessage}");
            CallResponse(id, responseMessage);
        }
        else if (splittedResponse.Length == 1)
        {
            id = "server";
            responseMessage = splittedResponse[0];
            Debug.Log($"{typeof(ResponsesDictionary)}: Received Message: id = {id} ; message = {responseMessage}");
            CallResponse(id, responseMessage);
        }
    }
    
    public void CallResponse(string id, string responseMessage)
    {
        if (id == "server")
        {
            childResponse.ResponseToMessage(responseMessage);
        }
        else
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

}