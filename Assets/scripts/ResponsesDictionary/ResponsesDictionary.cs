using UnityEngine;
using System;
using System.Collections.Generic;
using static AbstractResponse;

/// <summary>
/// Represents a dictionary of responses.
/// </summary>
public class ResponsesDictionary : MonoBehaviour
{
    private string id;
    private string responseMessage;
    [SerializeField]
    private Dictionary<string, AbstractResponse> responsesDictionary;
    [SerializeField]
    private List<AbstractResponse> childResponses;
    private AbstractResponse response;

    /// <summary>
    /// Initializes the responses dictionary.
    /// </summary>
    public void Start()
    {
        responsesDictionary = new Dictionary<string, AbstractResponse>();
    }

    /// <summary>
    /// Adds a response to the dictionary.
    /// </summary>
    /// <param name="key">The ID of the response.</param>
    /// <param name="value">The response method class.</param>
    public void AddResponse(string key, AbstractResponse value)
    {
        responsesDictionary.Add(key, value);
    }

    /// <summary>
    /// Checks the received message and calls the corresponding response method.
    /// </summary>
    /// <param name="response">The received message.</param>
    public void CheckResponse(string response)
    {
        string[] splittedResponse = response.Split(' ');
        if (splittedResponse.Length != 2 && splittedResponse.Length != 1)
        {
            Debug.LogWarning("Received message must contain 1 (only message) or 2 (id and message) words.");
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
            Debug.Log($"{typeof(ResponsesDictionary)} {responseMessage == splittedResponse[0]}");
            Debug.Log($"{typeof(ResponsesDictionary)}: {response}");
            CallResponse(id, responseMessage);
        }
    }
    
    /// <summary>
    /// Calls the response method based on the ID and response message.
    /// </summary>
    /// <param name="id">The ID of the response.</param>
    /// <param name="responseMessage">The response message.</param>
    public void CallResponse(string id, string responseMessage)
    {
        if (id == "server")
        {
            childResponses[0].ResponseToMessage(responseMessage);
        }
        else
        {
            if (responsesDictionary.TryGetValue(id, out response))
            {
                response.ResponseToMessage(responseMessage);
            }
            else
            {
                Debug.LogWarning($"{typeof(ResponsesDictionary)}: Key {id} not found in ResponsesDictionary");
            }
        }
    }
}