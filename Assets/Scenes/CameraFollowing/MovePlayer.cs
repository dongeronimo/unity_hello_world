using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;
    public float movementCoeficent = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var verticalMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        var horizontalMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        player.transform.position = player.transform.position +
            new Vector3(horizontalMovement, 0, verticalMovement);
    }
   

}
