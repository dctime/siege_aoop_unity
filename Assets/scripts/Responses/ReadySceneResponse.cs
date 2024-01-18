using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AbstractResponse;

public class ReadySceneResponse : AbstractResponse
{
    [SerializeField]
    private UserRegister userRegister;
    
    public override void ResponseToMessage(string responseMessage)
    {
        switch (responseMessage)
        {
        }
    }
}