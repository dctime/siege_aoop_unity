using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhowinCommandPublisher : AbstractPublisher
{
    public void PublishWhoWin()
    {
        PublishMessage("whowin");
    }
}
