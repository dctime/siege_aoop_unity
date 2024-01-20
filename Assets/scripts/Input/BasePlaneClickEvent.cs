using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Security.Policy;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasePlaneClickEvent : MonoBehaviour, IPointerClickHandler
{
    public OperatorActionController currentServerOperatorActionController;
    private PlayerSettingUpPlacer playerSettingUpPlacer;
    private PlayerSettingUpFlagPlacer playerSettingUpFlagPlacer;

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

    public void SetPlayerSettingUpFlagPlacer(PlayerSettingUpFlagPlacer playerSettingUpFlagPlacer)
    {
        this.playerSettingUpFlagPlacer = playerSettingUpFlagPlacer;
    }

    public PlayerSettingUpFlagPlacer GetPlayerSettingUpFlagPlacer()
    {
        return playerSettingUpFlagPlacer;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log($"{eventData.pointerCurrentRaycast.worldPosition}");
        float MapX = eventData.pointerCurrentRaycast.worldPosition.z;
        float MapY = eventData.pointerCurrentRaycast.worldPosition.x;

        // Debug.Log($"is {currentServerOperatorActionController} null?");
        if (currentServerOperatorActionController != null) 
        {
            currentServerOperatorActionController.basePlaneClickEventListener(MapX, MapY);
        }

        if (playerSettingUpPlacer != null)
        {
            playerSettingUpPlacer.basePlaneClickEventListener(MapX, MapY);
        }
        
        if (playerSettingUpFlagPlacer != null)
        {
            playerSettingUpFlagPlacer.basePlaneClickEventListener(MapX, MapY);
        }

    }
}



