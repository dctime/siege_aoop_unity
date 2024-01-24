using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

/// <summary>
/// It inherits from the AbstractPublisher class.
/// </summary>
public class PlayAsAttackerButtonPublisher : AbstractPublisher
{
    [SerializeField]
    private Text playerName;

    public override void PublisherAction()
    {
        // Update the player name if it is not empty
        if (this.playerName.text != "")
        {
            userRegister.SetPlayerName(this.playerName.text);
        }
        userRegister.SetPlayerIdentity("attacker");
        Debug.Log($"{this.Topic}: ({this.userRegister.GetPlayerName()}) is trying to become an attacker");
        PublishMessage($"signin A {this.userRegister.GetPlayerName()}");
    }
}
