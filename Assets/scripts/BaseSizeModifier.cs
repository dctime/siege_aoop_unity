using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class BaseSizeModifier : MonoBehaviour
{
    [SerializeField]
    int x;

    [SerializeField]
    int z;

    void Start()
    {
        transform.localScale = new Vector3(x, transform.localScale.y, z);
    }

}
