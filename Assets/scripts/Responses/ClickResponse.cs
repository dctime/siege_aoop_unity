using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It inherits from the AbstractResponse class.
/// </summary>
public class ClickResponse : AbstractResponse
{
    public override void ResponseToMessage(string responseMessage)
    {
        if (responseMessage == "success")
        {
            Debug.Log("Click Success");
        }
        else
        {
            Debug.LogWarning("Click Failed");
        }
    }
}
