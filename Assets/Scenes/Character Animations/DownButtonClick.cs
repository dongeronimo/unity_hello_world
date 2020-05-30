using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DownButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PeasantActions peasant;

    public void OnPointerDown(PointerEventData data)
    {
        peasant.SettingAxesManually = true;
        peasant.VerticalAxis = -1.0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        peasant.SettingAxesManually = true;
        peasant.VerticalAxis = 0.0f;
    }
}
