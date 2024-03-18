using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float speed = 5f; // Ajuste este valor conforme necessário
    public float rotationSpeed = 100f; // Velocidade de rotação da câmera
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
        // Perseguir o jogador mantendo o offset inicial
        Vector3 targetPosition = player.transform.position + offset;
        if (targetPosition.x >= -2)
        {
            targetPosition.x = -2;
        }
        if (targetPosition.z < -47)
        {
            targetPosition.z = -47;
        }
        if (targetPosition.x <= -13)
        {
            targetPosition.x = -13;
        }
        if (targetPosition.y >= 13)
        {
            targetPosition.y = 13;
        }
        
       

        
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        // Rotação em torno do jogador
        if (inputVector.x != 0)
        {
            Quaternion rotation = Quaternion.Euler(0f, inputVector.x * rotationSpeed * Time.deltaTime, 0f);
            offset = rotation * offset;

            if (offset.x >= 2)
            {
                offset.x = 2;
            }
            if (offset.z <= -47)
            {
                offset.z = -47;
            }
            if (offset.x <= -13)
            {
                offset.x = -13;
            }
            if (offset.y >= 13)
            {
                offset.y = 13;
            }
            
            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform); // Garante que a câmera sempre olhe para o jogador
        }
    }
}
