using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles the click event on a button and publishes the click event to a ClickPublisher.
/// </summary>
public class ClickEvent : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Animator animator;

    int clickTimes = 0;

    [SerializeField]
    ClickPublisher clickPublisher;

    /// <summary>
    /// Called when a pointer click event occurs.
    /// </summary>
    /// <param name="eventData">The pointer event data.</param>
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"I Click {clickTimes} Times");
        clickPublisher.ClickPublish();
        clickTimes++;
        animator.Play("New Animation");
    }
}
