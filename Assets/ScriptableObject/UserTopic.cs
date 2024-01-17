using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Topic", menuName = "Topic")]
public class UserTopic : ScriptableObject
{
    [SerializeField]
    private string userTopicName;

    public void OnEnable()
    {
        this.userTopicName = "connect";
    }

    public void SetTopicName(string userTopicName)
    {
        this.userTopicName = userTopicName;
    }

    public string GetTopicName()
    {
        return this.userTopicName;
    }
}
