using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Animator animator;

    int clickTimes = 0;

    [SerializeField]
    ClickPublisher clickPublisher;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"I Click {clickTimes} Times");
        clickPublisher.ClickPublish();
        clickTimes++;
        animator.Play("New Animation");

    }
}
