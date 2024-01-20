using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasePlaneClickEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public OperatorActionController currentServerOperatorActionController;

    public void SetOperatorActionController(OperatorActionController operatorActionController)
    {
        this.currentServerOperatorActionController = operatorActionController;
        Debug.Log($"{currentServerOperatorActionController} is now the new operator");
        print();
    }

    public void print()
    {
        Debug.Log($"Its still here! {currentServerOperatorActionController}");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"{eventData.pointerCurrentRaycast.worldPosition}");
        float MapX = eventData.pointerCurrentRaycast.worldPosition.z;
        float MapY = eventData.pointerCurrentRaycast.worldPosition.x;

        Debug.Log($"is {currentServerOperatorActionController} null?");
        currentServerOperatorActionController.basePlaneClickEventListener(MapX, MapY);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}



