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

    private string playAsAttackerButtonId;

    [SerializeField]
    private ResponsesDictionary responsesDictionary;

    [SerializeField]
    private SigninResponse signinResponse;

    protected override void Start()
    {
        base.Start();
        message = new RosSharp.RosBridgeClient.MessageTypes.Std.String();
    }
    private void PublishMessage(System.String data)
    {
        playAsAttackerButtonId = Guid.NewGuid().ToString();
        message.data = playAsAttackerButtonId + ' ' + data;
        Debug.Log($"Publishing Data: {message.data}");
        Publish(message);
        responsesDictionary.AddResponse(playAsAttackerButtonId, signinResponse);
    }

    public void PlayAsAttackerAction()
    {
        Debug.Log($"{this.Topic} ({this.playerName.text}) is trying to become a attacker");
        PublishMessage($"signin A {this.playerName.text}");
    }
}
