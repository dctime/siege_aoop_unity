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
    private string playAsDefenderButtonId;
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
        playAsDefenderButtonId = Guid.NewGuid().ToString();
        message.data = playAsDefenderButtonId + ' ' + data;
        Debug.Log($"Publishing Data: {message.data}");
        Publish(message);
        responsesDictionary.AddResponse(playAsDefenderButtonId, signinResponse);
        Debug.Log($"Added id,response to dictionary");
    }

    public void PlayAsDefenderAction()
    {
        Debug.Log($"{this.Topic} ({this.playerName.text}) is trying to become a defender");
        PublishMessage($"signin D {this.playerName.text}");
    }
}

