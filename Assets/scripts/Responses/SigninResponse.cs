using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Response;

public class SigninResponse : Response
{
    public override void ResponseToMessage(string response)
    {
        string message = TruncateId(response);
        switch (message)
        {
            
            // client -> server: signin A dctime:
            // server -> client: id message
            // message:
                // success
                // args_len_error
                // already_signin
                // identity_error           
            case "success":
                Debug.Log("Signin successful");
                // switch to next scene
                break;
            case "args_len_error":
                Debug.Log("Signin args_len_error");
                // pop up error message
                break;
            case "already_signin":
                Debug.Log("Signin already_signin");
                // pop up error message
                break;
            case "identity_error":
                Debug.Log("Signin identity_error");
                // pop up error message
                break;
            default:
                Debug.Log($"Signin response not recognized: {message}");
                break;
        }
    }
}
