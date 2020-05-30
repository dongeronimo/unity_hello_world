using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantActions : MonoBehaviour
{
    public bool SettingAxesManually = false;
    public float HorizontalAxis = 0.0f;
    public float VerticalAxis = 0.0f;
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
        if (SettingAxesManually == false)
        {
            float v = Input.GetAxisRaw("Vertical");
            return v;
        }
        else
        {
            return VerticalAxis;
        }
    }

    private float GetHorizontalInput()
    {
        if (SettingAxesManually == false)
        { 
            float h = Input.GetAxisRaw("Horizontal");
            return h;
        }
        else
        {
            return HorizontalAxis;
        }
    }

    private void SetForwardMovement(float movementFactor)
    {
        animator.SetFloat("Forward", movementFactor);
    }

}
