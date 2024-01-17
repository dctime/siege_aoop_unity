using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;

public class ConnectServerSubscriber : UnitySubscriber<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    private string response;
    private bool isMessageReceived;
    [SerializeField]
    private ResponsesDictionary responsesDictionary;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (isMessageReceived)
            ProcessMessage();
    }

    private void ProcessMessage()
    {
        // Access the received Float64MultiArray data
        if (response != null)
        {
            Debug.Log("Received message: " + response);
        }
        isMessageReceived = false;
    }

    protected override void ReceiveMessage(RosSharp.RosBridgeClient.MessageTypes.Std.String message)
    {
        response = message.data;
        isMessageReceived = true;
    }
}
