using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    private Vector3 limit;

    void Start()
    {
 // Calculate the initial offset between the camera's position and the player's position.
        offset = transform.position - player.transform.position; 
    }
   
    // Update is called once per frame
    void LateUpdate()
    {
        limit = player.transform.position + offset;
        if (limit.z <= -47)
        {
            limit.z = -47;

        }
        if (limit.y >= 12){
            limit.y = 12;
        }
        transform.position = limit;  
  
    }
}
