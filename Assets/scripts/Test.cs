using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            target.GetComponent<OperatorMove>().Move(5, 7);
        }
    }
}
