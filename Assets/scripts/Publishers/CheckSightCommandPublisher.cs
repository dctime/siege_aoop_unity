using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It inherits from the AbstractPublisher class.
/// </summary>
public class CheckSightCommandPublisher : AbstractPublisher
{
    public void publishCheckSight(int operatorIndex)
    {
        PublishMessage($"checksight {operatorIndex}");
    }
}
