using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//TODO: Mandar pro boneco
//TODO: Ocultar se não estiver em browser mobile
public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IDragHandler, IEndDragHandler
{
    public Image JoystickTouchImage;
    public JoystickOrientationReceiver OrientationReceiver;
    private Vector2 lastEventPositionInScreenCoordinates = new Vector2();
    private bool isPressed = false;
    private void ApplyToReceiver(Vector2 movementAxes)
    {
        OrientationReceiver.SetOrientation(movementAxes);
    }
    private Vector2 GetEventPositionInLocalCoordinates(Vector2 position)
    {
        Vector2 joystickScreenCoordinates = GetComponent<RectTransform>().position;
        Vector2 eventScreenCoordinates = position;
        Vector2 eventLocalCoordinates = joystickScreenCoordinates - eventScreenCoordinates;
        return eventLocalCoordinates;
    }
    private Vector2 GetMovementAxes(Vector2 eventDataPosition)
    {
        var area = GetComponent<RectTransform>().rect;
        Vector2 positionInLocalCoord = GetEventPositionInLocalCoordinates(eventDataPosition);
        var horizontalMovement = -positionInLocalCoord.x / area.width * 2.0f;
        var verticalMovement = -positionInLocalCoord.y / area.height * 2.0f;
        var movementAxesVector = new Vector2(horizontalMovement, verticalMovement);
        movementAxesVector.Normalize();
        return movementAxesVector;
    }
    private void ModifyJoystickTouchImage(Vector2 newPosition)
    {
        JoystickTouchImage.GetComponent<RectTransform>().position = newPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        lastEventPositionInScreenCoordinates = eventData.position;
        isPressed = true;
        //throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lastEventPositionInScreenCoordinates = eventData.position;
        isPressed = false;
        //throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        lastEventPositionInScreenCoordinates = eventData.position;
        isPressed = true;
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        lastEventPositionInScreenCoordinates = eventData.position;
        isPressed = false;
        //throw new System.NotImplementedException();
    }
    public void Start()
    {
        JoystickTouchImage.enabled = false;
    }
    public void Update()
    {
        if(isPressed)
        {
            JoystickTouchImage.enabled = true;
            ModifyJoystickTouchImage(lastEventPositionInScreenCoordinates);
            Vector2 movementAxes = GetMovementAxes(lastEventPositionInScreenCoordinates);
            ApplyToReceiver(movementAxes);
        }
        else
        {
            JoystickTouchImage.enabled = false;
            ApplyToReceiver(new Vector2());
        }
    }
    /*
public void OnDrag(PointerEventData eventData)
{
  Debug.Log("OnDrag");
  ModifyJoystickTouchImage(eventData.position);
  Vector2 movementAxes = GetMovementAxes(eventData);
  ApplyToReceiver(movementAxes);
}

private void ApplyToReceiver(Vector2 movementAxes)
{
  OrientationReceiver.SetOrientation(movementAxes);
}

public void OnEndDrag(PointerEventData eventData)
{
  Debug.Log("OnDrag");
  ModifyJoystickTouchImage(eventData.position);
  Vector2 movementAxes = GetMovementAxes(eventData);
  ApplyToReceiver(movementAxes);
}

public void OnPointerDown(PointerEventData eventData)
{
  Debug.Log("OnDrag");
  JoystickTouchImage.enabled = true;
  ModifyJoystickTouchImage(eventData.position);
  Vector2 movementAxes = GetMovementAxes(eventData);
  ApplyToReceiver(movementAxes);
}

public void OnPointerUp(PointerEventData eventData)
{
  Debug.Log("OnDrag");
  JoystickTouchImage.enabled = false;
  ModifyJoystickTouchImage(eventData.position);
  Vector2 movementAxes = GetMovementAxes(eventData);
  ApplyToReceiver(movementAxes);
}
private void ModifyJoystickTouchImage(Vector2 newPosition)
{
  JoystickTouchImage.GetComponent<RectTransform>().position = newPosition;
}
private Vector2 GetEventPositionInLocalCoordinates(PointerEventData eventData)
{
  Vector2 joystickScreenCoordinates = GetComponent<RectTransform>().position;
  Vector2 eventScreenCoordinates = eventData.position;
  Vector2 eventLocalCoordinates = joystickScreenCoordinates - eventScreenCoordinates;
  return eventLocalCoordinates;
}
private Vector2 GetMovementAxes(PointerEventData eventData)
{
  var area = GetComponent<RectTransform>().rect;
  Vector2 positionInLocalCoord = GetEventPositionInLocalCoordinates(eventData);
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
*/
}
