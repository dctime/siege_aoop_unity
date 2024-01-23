using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
