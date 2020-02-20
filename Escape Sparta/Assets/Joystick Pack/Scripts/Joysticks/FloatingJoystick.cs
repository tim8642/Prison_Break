using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    public bool canmove;
    CanvasGroup changealpha;
    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);

        changealpha = GetComponent<CanvasGroup>();
        canmove = false;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
        changealpha.alpha = 1.0f;
        canmove = true;

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        changealpha.alpha = 0.5f;
        canmove = false;
    }
}