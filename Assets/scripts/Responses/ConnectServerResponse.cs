using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Response;

public class ConnectServerResponse : Response
{
    public override void ResponseToMessage(string response)
    {
        string message = TruncateId(response);
        switch (message)
        {
            // connect command all response:
                // args_must_be_0
                // client_A
                // client_B
                // full
                // fatal_error
            case "args_must_be_0":
                Debug.Log("ConnectServer args_must_be_0");
                // pop up error message
                break;
            case "client_A":
                Debug.Log("ConnectServer client_A");
                // assign 'client_A' to 'Topic'
                break;
            case "client_B":
                Debug.Log("ConnectServer client_B");
                // assign 'client_B' to 'Topic'
                break;
            case "full":
                Debug.Log("ConnectServer full");
                // pop up error message
                break;
            case "fatal_error":
                Debug.Log("ConnectServer fatal_error");
                // pop up error message
                break;
            default:
                Debug.Log($"Connect response not recognized: {message}");
                break;
        }
    }
}
