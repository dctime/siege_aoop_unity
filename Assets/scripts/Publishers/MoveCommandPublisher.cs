using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It inherits from the AbstractPublisher class.
/// </summary>
public class MoveCommandPublisher : AbstractPublisher
{
    public override void PublisherAction()
    {
        PublishMessage("move 3 1 1");
    }
}
