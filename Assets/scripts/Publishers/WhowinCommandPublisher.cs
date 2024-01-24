using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It inherits from the AbstractPublisher class.
/// </summary>
public class WhowinCommandPublisher : AbstractPublisher
{
    public void PublishWhoWin()
    {
        PublishMessage("whowin");
    }
}
