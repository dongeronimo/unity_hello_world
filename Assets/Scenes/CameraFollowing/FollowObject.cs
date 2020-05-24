using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject Target;
    public GameObject Camera;
    public Vector3 CameraPositionRelativeToTarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var cameraPosition = Target.transform.position + CameraPositionRelativeToTarget;
        Camera.transform.position = cameraPosition;
        Camera.transform.LookAt(Target.transform);    
    }
}
