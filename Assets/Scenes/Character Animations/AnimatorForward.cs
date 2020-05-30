using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorForward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var animator = GetComponent<Animator>();
        //transform.parent.position += animator.deltaPosition;
        //Debug.Log(animator.deltaPosition);
    }
    /*
    public void OnAnimatorMove()
    {
        var animator = GetComponent<Animator>();
        transform.parent.position += animator.deltaPosition;
    }*/
}

