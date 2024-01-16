using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

namespace RosSharp.RosBridgeClient
{
    [SerializeField]
    private Text playerName;

        private MessageTypes.Std.String message;

        protected override void Start()
        {
            base.Start();
            message = new MessageTypes.Std.String();
        }
        private void PublishMessage(System.String data)
        {

            // Populate the data in your Float64MultiArray here
            // For example:
            message.data = data;
            Debug.Log($"Publishing Data: {message.data}");
            Publish(message);
        }

    public void playAsDefenderAction()
    {
        Debug.Log($"{this.Topic} ({this.playerName.text}) is trying to become a defender");
        PublishMessage($"signin D {this.playerName.text}");
    }
}

