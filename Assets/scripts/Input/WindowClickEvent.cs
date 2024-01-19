using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowClickEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField]
    private BreakableWindow breakableWindow;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Window Clicked");
        if (breakableWindow.isBroken == false)
        {
            breakableWindow.breakWindow();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Window Down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Window Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Window Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Window Up");
    }
}
