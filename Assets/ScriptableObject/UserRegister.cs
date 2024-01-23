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
    [SerializeField]
    private int maxOperatorCount;
    [SerializeField]
    private int selfCount;
    [SerializeField]
    private int emenyCount;
    [SerializeField]
    private string gameResult;

    public void OnEnable()
    {
        this.userTopicName = "connect";
        this.userPlayerName = "player";
        this.userPlayerIdentity = "none";
        this.opponentPlayerName = "none";
        this.opponentPlayerIdentity = "none";
        this.maxOperatorCount = 2;
        this.selfCount = 0;
        this.emenyCount = 0;
        this.gameResult = "none";
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

    public void SetMaxOperatorCount(int maxOperatorCount) { this.maxOperatorCount = maxOperatorCount; }
    public int GetMaxOperatorCount() {  return this.maxOperatorCount; }

    public void SetSelfCount(int count) { this.selfCount = count; }
    public void SetEmenyCount(int count) { this.emenyCount = count; }
    public int GetSelfCount() { return this.selfCount; }
    public int GetEmenyCount() { return this.emenyCount; }

    public void SetGameResult(string result) { this.gameResult = result; }
    public string GetGameResult() { return this.gameResult; }

    
        

    
}
