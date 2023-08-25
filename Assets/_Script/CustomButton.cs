using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button, IPointerUpHandler, IPointerDownHandler
{
    private ButtonClickedEvent _onRelease = new ButtonClickedEvent();
    private ButtonClickedEvent _onPress = new ButtonClickedEvent();
    public ButtonClickedEvent onRelease => _onRelease;
    public ButtonClickedEvent onPress => _onPress;
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Debug.Log("[CustomButton] OnPointerUp");
        _onRelease?.Invoke();
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        Debug.Log("[CustomButton] OnPointerDown");
        _onPress?.Invoke();
    }
}
