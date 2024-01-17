using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

public class PlayAsAttackerButtonPublisher : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    [SerializeField]
    private Text playerName;

    private RosSharp.RosBridgeClient.MessageTypes.Std.String message;

    private Guid playAsAttackerButtonId;

    protected override void Start()
    {
        base.Start();
        message = new RosSharp.RosBridgeClient.MessageTypes.Std.String();
        playAsAttackerButtonId = Guid.NewGuid();
    }
    private void PublishMessage(System.String data)
    {

        // Populate the data in your Float64MultiArray here
        // For example:
        message.data = PlayAsAttackerButtonId + ' ' + data;
        Debug.Log($"Publishing Data: {message.data}");
        Publish(message);
    }

    public void playAsAttackerAction()
    {
        Debug.Log($"{this.Topic} ({this.playerName.text}) is trying to become a attacker");
        PublishMessage($"signin A {this.playerName.text}");
    }
}
