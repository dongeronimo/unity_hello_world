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
        float h = Input.GetAxisRaw("Horizontal"); //* Time.deltaTime;
        float v = Input.GetAxisRaw("Vertical"); //* Time.deltaTime;
        Debug.Log(v);
        animator.SetFloat("Forward", v);

    }
}
