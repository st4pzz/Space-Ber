using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float timer;
    public TextMeshProUGUI timerText;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public Transform cameraTransform; // Adiciona uma referência à câmera
    public float speed = 0;
    public float jumpForce = 0;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 20.0f;
        SetTimerText();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log("Game Over");
        }
        SetTimerText();
    }

    void SetTimerText()
    {
        timerText.text = "Time: " + Mathf.Max(0, Mathf.Ceil(timer)).ToString(); // Arredonda o tempo para cima e não mostra valores negativos
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movementDirection = new Vector3(movementX, 0.0f, movementY).normalized;
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0; // Ignora a inclinação para cima/baixo da câmera ao calcular o movimento
        Vector3 cameraRight = cameraTransform.right;
        
        Vector3 moveDirection = (cameraForward * movementY + cameraRight * movementX).normalized;

        rb.AddForce(moveDirection * speed);
    }

    private void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Usa ForceMode.Impulse para um pulo mais instantâneo
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
        }
        if (collision.gameObject.CompareTag("Timer"))
        {
            timer += 10.0f;
        }
    }
}
