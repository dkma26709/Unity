using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D playerBody;
    CapsuleCollider2D playerCollider;
    Animator animator;
    bool hasHorizontalSpeed;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float climbSpeed = 10f;
    [SerializeField] float jumpForce = 5f;


    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Run();
        Climb();
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
        if (inputValue.isPressed && playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //playerBody.AddForce(new Vector2(0f,10f));
            playerBody.velocity += new Vector2(0f, jumpForce);
        }
    }

    void Climb()
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            Vector2 ClimbVelocity = new Vector2(playerBody.velocity.x, moveInput.y * climbSpeed);
            playerBody.velocity = ClimbVelocity;
        }
    }
}
