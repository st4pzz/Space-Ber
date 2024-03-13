using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    
    private Vector3 offset= new Vector3(0f, 0f, 0.005f);
    // Start is called before the first frame update
   
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position += offset;
    }
}
