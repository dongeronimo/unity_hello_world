using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IDragHandler, IEndDragHandler
{
    public Image JoystickTouchImage;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag = " + eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag = " + eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown = " + eventData.position);
        JoystickTouchImage.enabled = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp = " + eventData.position);
        JoystickTouchImage.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        JoystickTouchImage.enabled = false;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
