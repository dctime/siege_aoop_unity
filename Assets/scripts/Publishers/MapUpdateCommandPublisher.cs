using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// It inherits from the AbstractPublisher class.
/// </summary>
public class MapUpdateCommandPublisher : AbstractPublisher
{
    public override void PublisherAction()
    {
        PublishMessage("mapupdate");
    }

    float timer = 0;
    bool startTimer = true;
    /// <summary>
    /// Updates the object once per frame.
    /// </summary>
    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;

            if (timer > 1) // Delay A bit
            {
                PublisherAction();
                startTimer = false;
            }

        }
    }
}
