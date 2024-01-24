using UnityEngine;
using System;


/// <summary>
/// Represents an abstract response to a message.
/// </summary>
public abstract class AbstractResponse : MonoBehaviour
{

    protected string[] splittedResponse;

    /// <summary>
    /// Responds to the given message.
    /// Need to imeplement this method in the child class.
    /// </summary>
    /// <param name="responseMessage">The message to respond to.</param>
    public virtual void ResponseToMessage(string responseMessage){}

    /// <summary>
    /// Splits the response message into an array of strings.
    /// </summary>
    /// <param name="responseMessage">The response message to split.</param>
    public void SplitResponse(string responseMessage)
    {
        splittedResponse = responseMessage.Split('_');
    }
}