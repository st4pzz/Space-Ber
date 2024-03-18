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
    
    public float speed = 0; 
    public float jumpForce = 0;

    private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        timer = 30.0f;
        SetTimerText();
    }
    void Update(){
        timer -= Time.deltaTime;
        if (timer <= 0){
            Debug.Log("Game Over");
        }
        SetTimerText();
    }
    void SetTimerText(){
        timerText.text = "Time: " + timer.ToString();
    }
     void OnMove (InputValue movementValue)
   {
     Vector2 movementVector = movementValue.Get<Vector2>(); 
     movementX = movementVector.x; 
    movementY = movementVector.y; 
    
   }


    private void FixedUpdate() 
   {
    Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
    rb.AddForce(movement * speed); 
   }

    private void OnJump()
    {
        
        if (isGrounded )
        {
            Vector3 movement = new Vector3 (0, jumpForce,0);
            rb.AddForce(movement); 
            isGrounded = false;
        }
        
        
        
    }   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        
        }
        if (collision.gameObject.CompareTag("Obstacle")){
            Debug.Log("Game Over");

        }
    }
 
 
}
