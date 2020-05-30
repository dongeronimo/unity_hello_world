using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class LeftButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PeasantActions peasant;
    public void OnPointerDown(PointerEventData data)
    {
        peasant.SettingAxesManually = true;
        peasant.HorizontalAxis = -1.0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        peasant.SettingAxesManually = true;
        peasant.HorizontalAxis = 0.0f;
    }
}
