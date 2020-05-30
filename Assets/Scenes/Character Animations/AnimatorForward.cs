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
            var parent = transform.parent;
            parent.position = parent.position + parent.forward * animator.GetFloat("Forward") * Time.deltaTime;
            /*
            Vector3 newPosition = transform.parent.position;
            newPosition.z += animator.GetFloat("Forward") * Time.deltaTime;
            transform.parent.position = newPosition;
            */           
        }
       
    } 
}

