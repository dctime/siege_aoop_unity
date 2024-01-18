using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AbstractResponse;

public class ConnectServerResponse : AbstractResponse
{
    [SerializeField]
    private UserRegister userRegister;
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
                Debug.Log($"{typeof(ConnectServerResponse)}: args_must_be_0");
                // pop up error message
                break;
            case "client_A":
                Debug.Log($"{typeof(ConnectServerResponse)}: client_A");
                userRegister.SetTopicName("client_A");
                SceneManager.LoadScene("SigninScene");
                // assign 'client_A' to 'Topic'
                break;
            case "client_B":
                Debug.Log($"{typeof(ConnectServerResponse)}: client_B");
                userRegister.SetTopicName("client_B");
                SceneManager.LoadScene("SigninScene");
                // assign 'client_B' to 'Topic'
                break;
            case "full":
                Debug.Log($"{typeof(ConnectServerResponse)}: full");
                // pop up error message
                break;
            case "fatal_error":
                Debug.Log($"{typeof(ConnectServerResponse)}: fatal_error");
                // pop up error message
                break;
            default:
                Debug.Log($"{typeof(ConnectServerResponse)}: Connect response not recognized: {responseMessage}");
                break;
        }
    }
}
