using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 100f;
    Vector2 moveInput;
    Rigidbody2D playerBody;

    void Awake() 
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }
    
    void Run()
    {
        playerBody.velocity = new Vector2(moveInput.x * moveSpeed, playerBody.velocity.y);
    }

    void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            playerBody.AddForce(new Vector2(0, jumpForce));
        }
    }
}
