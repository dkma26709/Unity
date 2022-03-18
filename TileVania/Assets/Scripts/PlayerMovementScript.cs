using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D playerBody;
    Animator animator;
    bool hasHorizontalSpeed;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpForce = 5f;


    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelcoity = new Vector2(moveInput.x * runSpeed, playerBody.velocity.y);
        playerBody.velocity = playerVelcoity;
        animator.SetBool("IsRunning", hasHorizontalSpeed);
    }

    void FlipSprite()
    {
        hasHorizontalSpeed = Mathf.Abs(playerBody.velocity.x) > Mathf.Epsilon;
        
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerBody.velocity.x),1f);
        }
    }

    void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            //playerBody.AddForce(new Vector2(0f,10f));
            playerBody.velocity += new Vector2(0f, jumpForce);
        }
    }
}
