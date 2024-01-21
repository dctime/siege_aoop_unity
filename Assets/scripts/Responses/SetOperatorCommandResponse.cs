using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOperatorCommandResponse : AbstractResponse
{
    public override void ResponseToMessage(string responseMessage)
    {
        // success_n_left
        string[] splittedresponseMessage = responseMessage.Split('_');

        if (splittedresponseMessage.Length != 3)
        {
            Debug.LogWarning("Length not equal to 3 How?");
        }
        else if (splittedresponseMessage[0] == "success" && splittedresponseMessage[2] == "left")
        {
            if (Int32.TryParse(splittedresponseMessage[1], out int countLeft))
            {
                // DO SOMETHING
            }
            else
            {
                Debug.LogWarning("Operator Count should be a int");
            }
        }
    }
}
