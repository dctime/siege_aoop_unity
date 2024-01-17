using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;

public class SigninSceneSubscriber : UnitySubscriber<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    private string responseString;
    private bool isMessageReceived;
    [SerializeField]
    private ResponsesDictionary responsesDictionary;
    [SerializeField]
    private UserTopic userTopicName;

    protected override void Start()
    {
        Topic = userTopicName.GetTopicName();
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
