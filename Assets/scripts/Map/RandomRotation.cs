using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.SetPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
        Debug.Log("ROTATE!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
