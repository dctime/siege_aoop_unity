using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Response;

public class SigninResponse : Response
{
    public void ResponseToMessage(string response)
    {
        string message = TruncateId(response);
        
    }
}
