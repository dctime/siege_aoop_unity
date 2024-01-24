using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

/// <summary>
/// The main class for the game director.
/// </summary>
public class GameDirectorMain : MonoBehaviour
{
    [SerializeField]
    private RequestCommandPublisher requestPublisher;

    [SerializeField]
    private WhowinCommandPublisher whowinPublisher;
    
    private int emenyClickCount;
    private int myClickCount;

    /// <summary>
    /// Gets the enemy click count.
    /// </summary>
    /// <returns>The enemy click count.</returns>
    public int GetEmenyClickCount() { return  emenyClickCount; }

    /// <summary>
    /// Gets the player's click count.
    /// </summary>
    /// <returns>The player's click count.</returns>
    public int GetMyClickCount() { return myClickCount; }

    /// <summary>
    /// Sets the click count for both the player and the enemy.
    /// </summary>
    /// <param name="myCount">The player's click count.</param>
    /// <param name="emenyCount">The enemy's click count.</param>
    public void SetClickCount(int myCount, int emenyCount) { this.myClickCount = myCount; this.emenyClickCount = emenyCount; }

    // Next update in second
    private float nextUpdate = 1;

    // Update is called once per frame
    void Update()
    {
        requestPublisher.PublishRequest();
        Vector3 basePos = theBase.transform.position;
        theBase.transform.position = new Vector3(basePos.x, percentToDepth(GetPercent()), basePos.z);

        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            UpdateEverySecond();
        }
    }

    [SerializeField]
    int counter = 60;
    bool isCounting = false;

    /// <summary>
    /// Starts the countdown.
    /// </summary>
    public void StartCountDown() { isCounting = true; }

    /// <summary>
    /// Gets the current countdown value.
    /// </summary>
    /// <returns>The current countdown value.</returns>
    public int GetCounting() {  return counter; }

    [SerializeField]
    private GameObject theBase;
    private float maxDepth = -4;
    private float minDepth = -1;

    private float percentToDepth(float percent)
    {
        Debug.LogWarning($"Depth: {(maxDepth - minDepth) * (percent)}");
        return (maxDepth - minDepth) * (percent);
    }

    private float GetPercent()
    {
        float my = (float)myClickCount;
        float em = (float)emenyClickCount;
        if (my + em == 0)
        {
            Debug.LogWarning($" Get Percent {(float)my}, {(float)(my + em)} {(float)(my) / (float)(1)}");
            return (float)(my) / (float)(1);
        }
        else
        {
            Debug.LogWarning($" Get Percent {(float)(my) / (float)(my + em)}");
            return (float)(my) / (float)(my + em);
        }
    }

    void UpdateEverySecond()
    {
        if (isCounting)
        {
            counter--;

            if (counter <= 0)
            {
                isCounting = false;
                whowinPublisher.PublishWhoWin();
            }
        }
    }
}
