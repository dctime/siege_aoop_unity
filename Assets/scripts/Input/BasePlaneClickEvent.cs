using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasePlaneClickEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public OperatorActionController currentServerOperatorActionController;
    private PlayerSettingUpPlacer playerSettingUpPlacer;

    public void SetOperatorActionController(OperatorActionController operatorActionController)
    {
        this.currentServerOperatorActionController = operatorActionController;
        Debug.Log($"{currentServerOperatorActionController} is now the new operator controller");
    }

    public void SetPlayerSettingUpPlacer(PlayerSettingUpPlacer playerSettingUpPlacer)
    {
        this.playerSettingUpPlacer = playerSettingUpPlacer;
        Debug.Log($"{this.playerSettingUpPlacer} is now the new player setting up controller");
    }

    public PlayerSettingUpPlacer GetPlayerSettingUpPlacer()
    {
        return playerSettingUpPlacer;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log($"{eventData.pointerCurrentRaycast.worldPosition}");
        float MapX = eventData.pointerCurrentRaycast.worldPosition.z;
        float MapY = eventData.pointerCurrentRaycast.worldPosition.x;

        // Debug.Log($"is {currentServerOperatorActionController} null?");
        currentServerOperatorActionController.basePlaneClickEventListener(MapX, MapY);
        playerSettingUpPlacer.basePlaneClickEventListener(MapX, MapY);
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



