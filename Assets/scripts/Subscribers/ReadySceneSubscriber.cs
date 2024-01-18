using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;

public class ReadySceneSubscriber : UnitySubscriber<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    private string responseString;
    private bool isMessageReceived;
    [SerializeField]
    private ResponsesDictionary responsesDictionary;
    [SerializeField]
    private UserRegister userRegister;

    protected override void Start()
    {
        Topic = "/server_" + userRegister.GetTopicName();
        base.Start();
    }

    private void Update()
    {
        if (isMessageReceived)
            ProcessMessage();
    }

    private void ProcessMessage()
    {
        if (this.responseString != null)
        {
            responsesDictionary.CheckResponse(this.responseString);
        }   
        isMessageReceived = false;
    }

    protected override void ReceiveMessage(RosSharp.RosBridgeClient.MessageTypes.Std.String message)
    {
        responseString = message.data;
        isMessageReceived = true;
    }
}
