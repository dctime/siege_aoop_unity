using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Topic", menuName = "Topic")]
public class Topic : ScriptableObject
{
    private string topicName = "/signin";

    public void SetTopicName(string topicName)
    {
        this.topicName = topicName;
    }

    public string GetTopicName()
    {
        return this.topicName;
    }
}
