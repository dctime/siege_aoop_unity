using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OperatorClickEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField]
    OperatorAnimationController controller;
    public void OnPointerClick(PointerEventData eventData)
    {
        controller.PlayDeathAnimation();
        Debug.Log("Operator Clicked");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Operator Down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        controller.PlayJumpAnimation();
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
