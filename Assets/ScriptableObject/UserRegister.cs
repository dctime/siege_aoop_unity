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

    public void OnEnable()
    {
        this.userTopicName = "connect";
        this.userPlayerName = "player";
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
}
