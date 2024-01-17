using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

public class ConnectServerButtonPublisher : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    private RosSharp.RosBridgeClient.MessageTypes.Std.String message;
    private string connectServerId;
    [SerializeField]
    private ResponsesDictionary responsesDictionary;
    [SerializeField]
    private ConnectServerResponse connectServerResponse;
    [SerializeField]
    private UserTopic userTopicName;
    private string publicationId;
    private RosConnector rosConnector;

    protected override void Start()
    {
        rosConnector = GetComponent<RosConnector>();
        publicationId = rosConnector.RosSocket.Advertise<RosSharp.RosBridgeClient.MessageTypes.Std.String>(userTopicName.GetTopicName());
        message = new RosSharp.RosBridgeClient.MessageTypes.Std.String();
    }

    private void PublishMessage(System.String data)
    {
        connectServerId = Guid.NewGuid().ToString();
        message.data = connectServerId + ' ' + data;
        Debug.Log($"Publishing Data: {message.data}");
        Publish(message);
        responsesDictionary.AddResponse(connectServerId, connectServerResponse);
        Debug.Log($"Added id,response to dictionary");
    }

    public void ConnectServerAction()
    {
        Debug.Log($"{this.Topic} is trying to connect to server");
        PublishMessage($"connect");
    }
}
