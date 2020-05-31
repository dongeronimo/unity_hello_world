using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickOrientationReceiver : MonoBehaviour
{
    public void SetOrientation(Vector2 normalizedOrientation)
    {
        //Debug.Log("SetOrientation " + normalizedOrientation);
        //TODO: Aplicar o movimento forward/backward.
        var animator = GetComponent<Animator>();
        animator.SetFloat("Forward", normalizedOrientation.y);
        //TODO: Aplicar o movimento de rotaçào
        transform.parent.transform.Rotate(new Vector3(0, 1, 0), 90 *normalizedOrientation.x* Time.deltaTime);
    }
}
