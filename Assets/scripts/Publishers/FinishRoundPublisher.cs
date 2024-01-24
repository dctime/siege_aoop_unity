using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It inherits from the AbstractPublisher class.
/// </summary>
public class FinishRoundPublisher : AbstractPublisher
{
    public override void PublisherAction()
    {
        PublishMessage("finishround");
    }
}
