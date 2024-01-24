using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It inherits from the AbstractResponse class.
/// </summary>
public class ButtonClickerServerResponse : AbstractResponse
{
    [SerializeField]
    GameDirectorMain gameDirectorMain;
    public override void ResponseToMessage(string responseMessage)
    {
        
        if (responseMessage == "Play")
        {
            gameDirectorMain.StartCountDown();
        }
    }
}
