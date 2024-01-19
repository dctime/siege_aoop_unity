using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class BaseSizeModifier : MonoBehaviour
{
    void Start()
    {
        
    }

    public void SetBaseSize(int x, int y)
    {
        transform.localScale = new Vector3(y, 1, x);
    }

}
