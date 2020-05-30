# Joystick Controller

Serve para fazer o controller de joystick para mobile. 

# Implementação
## JoystickController
### EventSystems
- Usa o UnityEngine.EventSystems. Nesse EventSystems a classe descendente de MonoBehaviour implementa certas interfaces e a Unity envia os eventos nos game objects para o mono behaviour. Implementar a interface indica interesse no evento.
- As interfaces que interessam são: IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler. 
- Todos esses eventos tem como parâmetro um objeto do tipo PointerEventData. Esse objeto tem uma propriedade chamada Position, um Vector2, no sistema de coordenadas da janela, com a origem no canto inferior esquerdo.

### Mostrando a bolinha de toque
- O JoystickController tem agora propriedade pública UI.Image de nome JoystickTouchImage. 
- A JoystickTouchImage começa com enabled = false.
- No OnPointerDown o JoystickTouchImage fica true.
- No OnPointerUp o JoystickTouchImage fica false.
