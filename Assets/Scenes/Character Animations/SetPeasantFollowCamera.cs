using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPeasantFollowCamera : MonoBehaviour
{
    public Camera CharacterCamera;
    public Transform POV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterCamera.transform.position = POV.position;
        CharacterCamera.transform.LookAt(this.transform.position);
    }
}
