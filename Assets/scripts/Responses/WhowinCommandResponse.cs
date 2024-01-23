using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhowinCommandResponse : AbstractResponse
{
    [SerializeField]
    private UserRegister userRegister;

    public override void ResponseToMessage(string responseMessage)
    {
        string[] splittedResponseMessage = responseMessage.Split('_');

        if (splittedResponseMessage.Length == 4 && splittedResponseMessage[0] == "success")
        { 
            userRegister.SetSelfCount(Int32.Parse(splittedResponseMessage[2]));
            userRegister.SetEmenyCount(Int32.Parse(splittedResponseMessage[3]));
            

            switch (splittedResponseMessage[1]) 
            {
                case "win":
                    userRegister.SetGameResult("win");
                    SceneManager.LoadScene("EndScene");
                    break;

                case "lose":
                    userRegister.SetGameResult("lose");
                    SceneManager.LoadScene("EndScene");
                    break;

                case "draw":
                    userRegister.SetGameResult("draw");
                    SceneManager.LoadScene("EndScene");
                    break;
            }
            
        }
    }
}
