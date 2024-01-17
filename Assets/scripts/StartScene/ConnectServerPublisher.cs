using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

public class ConnectServerPublisher : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    private RosSharp.RosBridgeClient.MessageTypes.Std.String message;
    
    private Guid connectServerId;

    [SerializeField]
    private PublisheridDictionary publisheridDictionary;

    protected override void Start()
    {
        base.Start();
        message = new RosSharp.RosBridgeClient.MessageTypes.Std.String();
        connectServerId = Guid.NewGuid();
        publisheridDictionary.addPublisherid("connectServerId", connectServerId);
    }

    private void PublishMessage(System.String data)
    {
        message.data = connectServerId + " " + data;
        Debug.Log($"Publishing Data: {message.data}");
        Publish(message);
    }

    public void connectServerAction()
    {
        Debug.Log($"{this.Topic} is trying to connect to server");
        PublishMessage($"connect");
    }
}
