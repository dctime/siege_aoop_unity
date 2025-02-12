using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It inherits from the AbstractPublisher class.
/// </summary>
public class ReadyPublisher : AbstractPublisher
{
    public override void PublisherAction()
    {
        PublishMessage("ready");
    }

    float timer = 0;
    bool startTimer = true;
    float maxTime;
    /// <summary>
    /// Updates the object once per frame.
    /// </summary>
    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;

            if (userRegister.GetPlayerIdentity() == "attacker")
            {
                maxTime = 3;
            }
            else if (userRegister.GetPlayerIdentity() == "defender")
            {
                maxTime = 2;
            }

            if (timer > maxTime) // Delay A bit
            {
                PublisherAction();
                startTimer = false;
            }

        }
    }
}
