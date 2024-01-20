using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OperatorActionController : MonoBehaviour, IPointerClickHandler
{
    public BasePlaneClickEvent basePlaneClickEvent;

    [SerializeField]
    private GameObject indicatorObject;

    [SerializeField]
    private OperatorMove operatorMove;

    [SerializeField]
    private UserRegister userRegister;

    private bool isChosen = false;

    private void Update()
    {
        if (basePlaneClickEvent != null) { GetBasePlaneClickEvent(); }
    }

    private void GetBasePlaneClickEvent()
    {
        GameObject mapObject = GameObject.Find("Map");

        if (mapObject.GetComponent<JsonMapBuilder>().GetBasePlaneObject()
                .GetComponent<BaseSizeModifier>().GetBasePlane().GetComponent<BasePlaneClickEvent>() != null)
        {
            basePlaneClickEvent = mapObject.GetComponent<JsonMapBuilder>().GetBasePlaneObject()
                .GetComponent<BaseSizeModifier>().GetBasePlane().GetComponent<BasePlaneClickEvent>();
        }
        else
        {
            Debug.LogWarning("Cannot get map Object");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void basePlaneClickEventListener(float MapX, float MapY)
    {
        // Debug.Log("Something from basePlaneListener");
        if (isChosen) 
        {
            operatorMove.Move(MapX, MapY);
        }
    }

}
