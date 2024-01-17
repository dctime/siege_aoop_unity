using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractResponse;

public class SigninResponse : AbstractResponse
{
    public override void ResponseToMessage(string responseMessage)
    {
        switch (responseMessage)
        {
            
            // client -> server: signin A dctime:
            // server -> client: id message
            // message:
                // success
                // args_len_error
                // already_signin
                // identity_error           
            case "success":
                Debug.Log("SigninResponse: successful");
                // switch to next scene
                break;
            case "args_len_error":
                Debug.Log("SigninResponse: args_len_error");
                // pop up error message
                break;
            case "already_signin":
                Debug.Log("SigninResponse: already_signin");
                // pop up error message
                break;
            case "identity_error":
                Debug.Log("SigninResponse: identity_error");
                // pop up error message
                break;
            default:
                Debug.Log($"SigninResponse: response not recognized: {responseMessage}");
                break;
        }
    }
}
