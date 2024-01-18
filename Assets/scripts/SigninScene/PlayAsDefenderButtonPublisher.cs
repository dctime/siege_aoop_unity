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
        playAsDefenderButtonId = Guid.NewGuid().ToString();
        message.data = playAsDefenderButtonId + ' ' + data;
        Debug.Log($"Publishing Data: {message.data}");
        Publish(message);
        responsesDictionary.AddResponse(playAsDefenderButtonId, signinResponse);
        Debug.Log($"{typeof(PlayAsDefenderButtonPublisher)}: Added id and response to dictionary");
    }

    public void PlayAsDefenderAction()
    {
        if (this.playerName.text != "")
        {
            userRegister.SetPlayerName(this.playerName.text);
        }
        Debug.Log($"{this.Topic}: ({this.userRegister.GetPlayerName()}) is trying to become a defender");
        PublishMessage($"signin D {this.userRegister.GetPlayerName()}");
    }
}

