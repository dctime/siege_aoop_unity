using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It inherits from the AbstractResponse class.
/// </summary>
public class ClickCommandResponse : AbstractResponse
{
    [SerializeField]
    GameDirectorMain gameDirectorMain;
    public override void ResponseToMessage(string responseMessage)
    {

        string[] splittedResponseMessage = responseMessage.Split('_');

        if (splittedResponseMessage[0] == "success")
        {
            
            int ourCount = Int32.Parse(splittedResponseMessage[1]);
            int emenyCount = Int32.Parse(splittedResponseMessage[2]);
            Debug.LogWarning($"Get my count:{ourCount} emenyCount:{emenyCount}");
            gameDirectorMain.SetClickCount(ourCount, emenyCount);
            
        }
    }
}
