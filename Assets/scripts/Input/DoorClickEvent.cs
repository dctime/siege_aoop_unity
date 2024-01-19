using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorClickEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField]
    private GameObject door;

    public void OnPointerClick(PointerEventData eventData)
    {
        door.GetComponent<ExtendDirection>().SwapDirection();
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
