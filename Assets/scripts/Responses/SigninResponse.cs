using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static AbstractResponse;

public class SigninResponse : AbstractResponse
{
    [SerializeField]
    private Button playAsAttackerButton;
    [SerializeField]
    private Button playAsDefenderButton;

    public override void ResponseToMessage(string responseMessage)
    {
        switch (responseMessage)
        {          
            case "success":
                Debug.Log($"{typeof(SigninResponse)}: successful");
                // switch to next scene
                break;
            case "args_len_error":
                Debug.Log($"{typeof(SigninResponse)}: args_len_error");
                // pop up error message
                break;
            case "already_signin":
                Debug.Log($"{typeof(SigninResponse)}: already_signin");
                // pop up error message
                break;
            case "identity_error":
                Debug.Log($"{typeof(SigninResponse)}: identity_error");
                // pop up error message
                break;
            case "attacker_occupied":
                Debug.Log($"{typeof(SigninResponse)}: {responseMessage}");
                playAsAttackerButton.interactable = false;
                break;
            case "defender_occupied":
                Debug.Log($"{typeof(SigninResponse)}: {responseMessage}");
                playAsDefenderButton.interactable = false;
                break;
        }
    }
}
