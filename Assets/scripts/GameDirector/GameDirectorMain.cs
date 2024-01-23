using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameDirectorMain : MonoBehaviour
{
    [SerializeField]
    private RequestCommandPublisher requestPublisher;

    [SerializeField]
    private WhowinCommandPublisher whowinPublisher;
    

    private int emenyClickCount;
    private int myClickCount;

    public int GetEmenyClickCount() { return  emenyClickCount; }
    public int GetMyClickCount() { return myClickCount;}
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

    // Update is called once per second

    [SerializeField]
    int counter = 60;
    bool isCounting = false;

    public void StartCountDown() { isCounting = true; }


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
