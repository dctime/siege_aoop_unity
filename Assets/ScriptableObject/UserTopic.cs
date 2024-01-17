using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Topic", menuName = "Topic")]
public class UserTopic : ScriptableObject
{
    private string userTopicName = "/signin";

    public void SetTopicName(string userTopicName)
    {
        this.userTopicName = userTopicName;
    }

    public string GetTopicName()
    {
        return this.userTopicName;
    }
}
