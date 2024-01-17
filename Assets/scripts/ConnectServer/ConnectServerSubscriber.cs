using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;

public class ConnectServerSubscriber : UnitySubscriber<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    private string response_string;
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
        if (this.response_string != null)
        {
            string[] splitted_response = this.response_string.Split(' ');
            if (splitted_response.Length != 2)
            {
                throw new System.Exception("Received message must contain 2 words id and response message");
            }

            string id = splitted_response[0];
            string response_message = splitted_response[1];
            Debug.Log($"Received Message: id = {id} message = {response_message}");
        }   
        isMessageReceived = false;
    }

    protected override void ReceiveMessage(RosSharp.RosBridgeClient.MessageTypes.Std.String message)
    {
        response_string = message.data;
        isMessageReceived = true;
    }
}
