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
    [SerializeField]
    private UserRegister userRegister;

    protected override void Start()
    {
        Topic = "/" + userRegister.GetTopicName();
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
        Debug.Log($"Added id and response to dictionary by {typeof(PlayAsAttackerButtonPublisher)}");
    }

    public void PlayAsAttackerAction()
    {
        if (this.playerName.text != "" || this.playerName.text != null)
        {
            userRegister.SetPlayerName(this.playerName.text);
        }
        Debug.Log($"{this.Topic} ({this.userRegister.GetPlayerName()}) is trying to become an attacker");
        PublishMessage($"signin A {this.userRegister.GetPlayerName()}");
    }
}
