using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorForward : MonoBehaviour
{
    void OnAnimatorMove()
    {
       
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            Vector3 newPosition = transform.parent.position;
            newPosition.z += animator.GetFloat("Forward") * Time.deltaTime;
            transform.parent.position = newPosition;
            /*
            Vector3 newPosition = transform.position;
            newPosition.z += animator.GetFloat("Forward") * Time.deltaTime;
            transform.position = newPosition;
            */
        }
       
    } 
}

