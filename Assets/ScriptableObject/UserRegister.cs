using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Topic", menuName = "Topic")]
public class UserRegister : ScriptableObject
{
    [SerializeField]
    private string userTopicName;
    [SerializeField]
    private string userPlayerName;
    [SerializeField]
    private string userPlayerIdentity;
    [SerializeField]
    private string opponentPlayerName;
    [SerializeField]
    private string opponentPlayerIdentity;  

    public void OnEnable()
    {
        this.userTopicName = "connect";
        this.userPlayerName = "player";
        this.userPlayerIdentity = "defender";
        this.opponentPlayerName = "none";
        this.opponentPlayerIdentity = "none";
    }

    public void SetTopicName(string userTopicName)
    {
        this.userTopicName = userTopicName;
    }

    public string GetTopicName()
    {
        return this.userTopicName;
    }

    public void SetPlayerName(string userPlayerName)
    {
        this.userPlayerName = userPlayerName;
    }

    public string GetPlayerName()
    {
        return this.userPlayerName;
    }

    public void SetPlayerIdentity(string userPlayerIdentity)
    {
        this.userPlayerIdentity = userPlayerIdentity;
    }

    public string GetPlayerIdentity()
    {
        return this.userPlayerIdentity;
    }

    public void SetOpponentPlayerName(string opponentPlayerName)
    {
        this.opponentPlayerName = opponentPlayerName;
    }

    public string GetOpponentPlayerName()
    {
        return this.opponentPlayerName;
    }

    public void SetOpponentPlayerIdentity(string opponentPlayerIdentity)
    {
        this.opponentPlayerIdentity = opponentPlayerIdentity;
    }

    public string GetOpponentPlayerIdentity()
    {
        return this.opponentPlayerIdentity;
    }

    
        

    
}
