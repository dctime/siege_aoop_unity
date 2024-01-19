using RosSharp.RosBridgeClient.MessageTypes.Geometry;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignRandomer : MonoBehaviour
{
    [SerializeField]
    GameObject sign1;

    [SerializeField]
    GameObject sign2;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            sign1.SetActive(false);
        }
        else if (rand == 1)
        {
            sign2.SetActive(false);
        }
    }
}
