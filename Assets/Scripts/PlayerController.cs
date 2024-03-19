using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float timer;
    public TextMeshProUGUI timerText;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public float speed = 0;
    public float jumpForce = 0;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 10.0f;
        SetTimerText();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("dead_scene");
        }
        SetTimerText();
    }

    void SetTimerText()
    {
        timerText.text = "Time: " + Mathf.Max(0, Mathf.Ceil(timer)).ToString();
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
        rb.AddForce(movementDirection * speed);
    }

    private void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacule"))
        {
            SceneManager.LoadScene("dead_scene");
        }
        if (collision.gameObject.CompareTag("Timer"))
        {
            
            timer = timer + 10.0f;
            SetTimerText();
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("ganhou");
            
        }
    }
}
