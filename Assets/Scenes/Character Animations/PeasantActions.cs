using System.Collections;
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
        float v = GetVerticalInput();
        float h = GetHorizontalInput();
        SetForwardMovement(v);
        if(h > 0)
        {
           // transform.RotateAround(new Vector3(0, 1, 0), 30) * Time.deltaTime;
           transform.Rotate(new Vector3(0, 1, 0), 30 * Time.deltaTime);
        }
        if(h < 0)
        {
            transform.Rotate(new Vector3(0, 1, 0), -30 * Time.deltaTime);
        }
    }

    private float GetVerticalInput()
    {
        float v = Input.GetAxisRaw("Vertical");
        return v;
    }

    private float GetHorizontalInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        return h;
    }

    private void SetForwardMovement(float movementFactor)
    {
        animator.SetFloat("Forward", movementFactor);
    }

}
