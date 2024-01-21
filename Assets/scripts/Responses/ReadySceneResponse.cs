using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static AbstractResponse;

public class ReadySceneResponse : AbstractResponse
{
    private string[] splittedResponse;
    [SerializeField]
    private UserRegister userRegister;
    [SerializeField]
    private Text userNameText;
    [SerializeField]
    private Text userIdentityText;
    [SerializeField]
    private Text opponentNameText;
    [SerializeField]
    private Text opponentIdentityText;

    private bool startTimer = false;
    
    public override void ResponseToMessage(string responseMessage)
    {
        SplitResponse(responseMessage);
        Debug.Log($"{typeof(ReadySceneResponse)}: responseMessage: {responseMessage}");
        if (splittedResponse[0] == "occupied")
        {
            userRegister.SetOpponentPlayerName(splittedResponse[2]);
            userRegister.SetOpponentPlayerIdentity(splittedResponse[1]);
            opponentNameText.text = "OPPONENT NAME:\n" + userRegister.GetOpponentPlayerName();
            opponentIdentityText.text = "OPPONENT PLAYS AS:\n" + userRegister.GetOpponentPlayerIdentity();
        }
        else if (responseMessage == "start_setting")
        {
            startTimer = true;
        }
    }

    float timer = 0;
    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;

            if (timer > 5)
            {
                SceneManager.LoadScene("SettingUpScene");
            }

        }
    }

    public void SplitResponse(string responseMessage)
    {
        splittedResponse = responseMessage.Split('_');
    }
}