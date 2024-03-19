using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float speed = 5f; 
    private Vector2 inputVector;

    void Start()
    {   
        offset = transform.position - player.transform.position; 
    }

    public void OnMove(InputValue movementValue)
    {
        inputVector = movementValue.Get<Vector2>();
    }

    void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position + offset;

        float limiteZMin = -30;
        float suaCondicaoZMin = player.transform.position.z >= -30 ? limiteZMin : -45;


        targetPosition.x = Mathf.Clamp(targetPosition.x, -13, -2);
        targetPosition.y = Mathf.Clamp(targetPosition.y, 0, 12); 
        targetPosition.z = Mathf.Clamp(targetPosition.z, suaCondicaoZMin, 100); 

        
        transform.position = targetPosition;
        
        
    }
}
