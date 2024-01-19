using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendDirection : MonoBehaviour
{
    public enum ExtendDirectionEnum
    {
        XDirection,
        YDirection
    }

    private ExtendDirectionEnum direction = ExtendDirectionEnum.XDirection;
    // Start is called before the first frame update
    void Start()
    {
        if (direction == ExtendDirectionEnum.XDirection)
        {
            gameObject.transform.eulerAngles = Vector3.zero;
        }
        else if (direction == ExtendDirectionEnum.YDirection)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
