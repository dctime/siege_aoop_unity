using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

public abstract class AbstractPublisher : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    protected RosSharp.RosBridgeClient.MessageTypes.Std.String message;
    protected string messageId;
    protected ResponsesDictionary responsesDictionary;
    [SerializeField]
    protected AbstractResponse abstractResponse;
    [SerializeField]
    protected UserRegister userRegister;

    protected override void Start()
    {
        Topic = "/" + userRegister.GetTopicName();
        base.Start();
        message = new RosSharp.RosBridgeClient.MessageTypes.Std.String();
    }

    protected void PublishMessage(System.String data)
    {
        messageId = Guid.NewGuid().ToString();
        message.data = messageId + ' ' + data;
        Debug.Log($"Publishing Data: {message.data}");
        Publish(message);
        responsesDictionary.AddResponse(messageId, abstractResponse);
        Debug.Log($"{typeof(AbstractPublisher)}: Added id and response to dictionary");
    }

    public void ConnectServerAction()
    {
        Debug.Log($"{this.Topic} is trying to connect to server");
        PublishMessage($"connect");
    }
}
