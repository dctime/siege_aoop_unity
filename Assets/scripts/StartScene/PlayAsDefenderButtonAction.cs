using JetBrains.Annotations;
using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

public class PlayAsDefenderButtonAction : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    [SerializeField]
    private System.String playerName;

    private RosSharp.RosBridgeClient.MessageTypes.Std.String message;

    protected override void Start()
    {
        base.Start();
        message = new RosSharp.RosBridgeClient.MessageTypes.Std.String();
    }
    private void PublishMessage(System.String data)
    {

        // Populate the data in your Float64MultiArray here
        // For example:
        message.data = data;

        Publish(message);
    }

    public void playAsDefenderAction()
    {
        Debug.Log($"{this.Topic} ({this.playerName}) is trying to become a defender");
        PublishMessage($"signin D {this.playerName}");
    }
}
