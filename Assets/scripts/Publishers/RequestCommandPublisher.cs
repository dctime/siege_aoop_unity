using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It inherits from the AbstractPublisher class.
/// </summary>
public class RequestCommandPublisher : AbstractPublisher
{
    public void PublishRequest()
    {
        PublishMessage("request");
    }
}
