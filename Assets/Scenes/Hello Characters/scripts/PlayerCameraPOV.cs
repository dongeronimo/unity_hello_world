using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraPOV : MonoBehaviour
{
    public Camera mCamera;
    public GameObject mPlayerRoot;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        mCamera.transform.position = this.transform.position;
        mCamera.transform.LookAt(mPlayerRoot.transform.position);
    }
}
