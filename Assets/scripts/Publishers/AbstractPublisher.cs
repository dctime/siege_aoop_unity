using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

/// <summary>
/// Represents an abstract publisher that publishes messages to a ROS topic.
/// </summary>
/// <typeparam name="T">The message type to be published.</typeparam>
public class AbstractPublisher<T> : UnityPublisher<T> where T : RosSharp.RosBridgeClient.Message
{
    protected T message;
    protected string messageId;
    [SerializeField]
    protected ResponsesDictionary responsesDictionary;
    [SerializeField]
    protected AbstractResponse abstractResponse;
    [SerializeField]
    protected UserRegister userRegister;

    /// <summary>
    /// Called when the publisher is started.
    /// </summary>
    protected override void Start()
    {
        Topic = "/" + userRegister.GetTopicName();
        base.Start();
        message = new T();
    }

    /// <summary>
    /// Publishes a message with the specified data.
    /// </summary>
    /// <param name="data">The data to be published.</param>
    protected void PublishMessage(System.String data)
    {
        messageId = Guid.NewGuid().ToString();
        message.data = messageId + ' ' + data;
        Debug.Log($"Publishing Data: {message.data}");
        Publish(message);
        responsesDictionary.AddResponse(messageId, abstractResponse);
        Debug.Log($"{typeof(AbstractPublisher<T>)}: Added id and response to dictionary");
    }

    /// <summary>
    /// Performs the action of the publisher.
    /// This method must be overridden by the child class. Add what you need to send to server.
    /// </summary>
    public virtual void PublisherAction()
    {
        Debug.Log($"{this.Topic} is speaking");
        PublishMessage($"need to override!");
    }
}
