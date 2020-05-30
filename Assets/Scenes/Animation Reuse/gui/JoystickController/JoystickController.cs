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
        ModifyJoystickTouchImage(eventData.position);
        Vector2 movementAxes = GetMovementAxes(eventData);
        //TODO: mandar pro boneco
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ModifyJoystickTouchImage(eventData.position);
        Vector2 movementAxes = GetMovementAxes(eventData);
        //TODO: mandar pro boneco
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        JoystickTouchImage.enabled = true;
        ModifyJoystickTouchImage(eventData.position);
        Vector2 movementAxes = GetMovementAxes(eventData);
        //TODO: mandar pro boneco
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        JoystickTouchImage.enabled = false;
        ModifyJoystickTouchImage(eventData.position);
        Vector2 movementAxes = GetMovementAxes(eventData);
        //TODO: mandar pro boneco
    }
    private void ModifyJoystickTouchImage(Vector2 newPosition)
    {
        JoystickTouchImage.GetComponent<RectTransform>().position = newPosition;
    }
    private Vector2 getEventPositionInLocalCoordinates(PointerEventData eventData)
    {
        Vector2 joystickScreenCoordinates = GetComponent<RectTransform>().position;
        Vector2 eventScreenCoordinates = eventData.position;
        Vector2 eventLocalCoordinates = joystickScreenCoordinates - eventScreenCoordinates;
        return eventLocalCoordinates;
    }
    private Vector2 GetMovementAxes(PointerEventData eventData)
    {
        var area = GetComponent<RectTransform>().rect;
        Vector2 positionInLocalCoord = getEventPositionInLocalCoordinates(eventData);
        var horizontalMovement = -positionInLocalCoord.x / area.width * 2.0f;
        var verticalMovement = -positionInLocalCoord.y / area.height * 2.0f;
        var movementAxesVector = new Vector2(horizontalMovement, verticalMovement);
        movementAxesVector.Normalize();
        return movementAxesVector;
    }
    void Start()
    {
        JoystickTouchImage.enabled = false;    
    }
    
    void Update()
    {
        
    }
}
