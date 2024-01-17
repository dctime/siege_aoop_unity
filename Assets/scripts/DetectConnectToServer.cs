using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;

public class DetectConnectToServer : UnitySubscriber<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    private string responseString;
    private bool isMessageReceived;
    [SerializeField]
    private UserTopic userTopicName;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    protected override void Start()
    {
        Topic = "/server_detect_" + userTopicName.GetTopicName();
        base.Start();
    }

    private void Update()
    {
        if (isMessageReceived)
            ProcessMessage();
    }

    private void ProcessMessage()
    {
        Debug.Log($"Received message: {responseString}");
        if (responseString == "safe"){}
        else if (responseString == "boom")
        {
            QuitGame();
        }
        isMessageReceived = false;
    }

    protected override void ReceiveMessage(RosSharp.RosBridgeClient.MessageTypes.Std.String message)
    {
        responseString = message.data;
        isMessageReceived = true;
    }

    public void QuitGame()
    {
        // save any game data here
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
