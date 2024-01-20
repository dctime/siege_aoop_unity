using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OperatorActionController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public BasePlaneClickEvent basePlaneClickEvent;

    [SerializeField]
    private GameObject indicatorObject;

    [SerializeField]
    private OperatorMove operatorMove;

    [SerializeField]
    private UserRegister userRegister;

    private bool isChosen = false;

    private void Start()
    {
        
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
        GetBasePlaneClickEvent();

        if (!isChosen) 
        {
            isChosen = true;
            basePlaneClickEvent.SetOperatorActionController(this);
            indicatorObject.SetActive(true);
        }
        else if (isChosen)
        {
            isChosen = false;
            indicatorObject.SetActive(false);
        }
    }

    public void basePlaneClickEventListener(float MapX, float MapY)
    {
        Debug.Log("Something from basePlaneListener");
        if (isChosen) 
        {
            operatorMove.Move(MapX, MapY);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }
}
