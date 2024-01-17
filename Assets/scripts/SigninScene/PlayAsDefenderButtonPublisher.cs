using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

public class PlayAsDefenderButtonPublisher : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    [SerializeField]
    private Text playerName;
    
    private RosSharp.RosBridgeClient.MessageTypes.Std.String message;

    private Guid playAsDefenderButtonId;

    protected override void Start()
    {
        base.Start();
        message = new RosSharp.RosBridgeClient.MessageTypes.Std.String();
        playAsDefenderButtonId = Guid.NewGuid();
    }
    private void PublishMessage(System.String data)
    {

        // Populate the data in your Float64MultiArray here
        // For example:
        message.data = playAsDefenderButtonId + ' ' + data;
        Debug.Log($"Publishing Data: {message.data}");
        Publish(message);
    }

    public void playAsDefenderAction()
    {
        Debug.Log($"{this.Topic} ({this.playerName.text}) is trying to become a defender");
        PublishMessage($"signin D {this.playerName.text}");
    }
}

