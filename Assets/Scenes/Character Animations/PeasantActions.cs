﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantActions : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxisRaw("Horizontal"); //* Time.deltaTime;
        float v = GetVerticalInput();
        SetForwardMovement(v);
    }

    private float GetVerticalInput()
    {
        float v = Input.GetAxisRaw("Vertical");
        return v;
    }

    private void SetForwardMovement(float movementFactor)
    {
        animator.SetFloat("Forward", movementFactor);
    }

    void OnAnimatorMove()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            Vector3 newPosition = transform.position;
            newPosition.z += animator.GetFloat("Forward") * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}