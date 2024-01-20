using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OperatorClickEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField]
    OperatorMove operatorMove;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Operator Clicked");
        operatorMove.Move(1.3f, 1.6f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Operator Down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Operator Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Operator Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Operator Up");
    }
}
