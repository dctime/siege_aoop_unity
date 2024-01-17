using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AbstractResponse;

public class ConnectServerResponse : AbstractResponse
{
    [SerializeField]
    private UserTopic userTopicName;
    public override void ResponseToMessage(string responseMessage)
    {
        switch (responseMessage)
        {
            // connect command all response:
                // args_must_be_0
                // client_A
                // client_B
                // full
                // fatal_error
            case "args_must_be_0":
                Debug.Log("ConnectServerResponse: args_must_be_0");
                // pop up error message
                break;
            case "client_A":
                Debug.Log("ConnectServerResponse: client_A");
                userTopicName.SetTopicName("client_A");
                SceneManager.LoadScene("SigninScene");
                // assign 'client_A' to 'Topic'
                break;
            case "client_B":
                Debug.Log("ConnectServerResponse: client_B");
                userTopicName.SetTopicName("client_B");
                SceneManager.LoadScene("SigninScene");
                // assign 'client_B' to 'Topic'
                break;
            case "full":
                Debug.Log("ConnectServerResponse: full");
                // pop up error message
                break;
            case "fatal_error":
                Debug.Log("ConnectServerResponse: fatal_error");
                // pop up error message
                break;
            default:
                Debug.Log($"ConnectServerResponse: Connect response not recognized: {responseMessage}");
                break;
        }
    }
}
