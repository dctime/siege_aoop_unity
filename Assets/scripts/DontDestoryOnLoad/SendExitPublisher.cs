using RosSharp.RosBridgeClient;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SendExitPublisher : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    private RosSharp.RosBridgeClient.MessageTypes.Std.String message;
    private string connectServerId;

    [SerializeField]
    private UserRegister userRegister;

    private void OnApplicationQuit()
    {
        Topic = userRegister.GetTopicName();
        PublishMessage("exit");
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);        
    }

    protected override void Start()
    {
        base.Start();
        message = new RosSharp.RosBridgeClient.MessageTypes.Std.String();
    }

    private void PublishMessage(string data)
    {
        connectServerId = Guid.NewGuid().ToString();
        message.data = connectServerId + ' ' + data;
        Debug.Log($"Publishing Data: {message.data}, topic: {this.Topic}");
        Publish(message);
    }
}
