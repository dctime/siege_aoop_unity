using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OperatorClickEvent : MonoBehaviour, IPointerClickHandler
{
    private PlayerGameFlow playerGameFlow;

    [SerializeField]
    private GameObject indicator;

    public void SetPlayerGameFlow(PlayerGameFlow playerGameFlow)
    {
        this.playerGameFlow = playerGameFlow;
    }

    public GameObject GetIndicator()
    {
        return indicator;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (indicator.activeSelf == true)
        {
            playerGameFlow.WhenNowControllerOperatorIsClick();
        }
    }
}
