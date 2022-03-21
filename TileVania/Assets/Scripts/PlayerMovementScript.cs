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
    bool hasVerticalSpeed;
    bool isClimbing;
    float gravityScaleAtStart;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float climbSpeed = 10f;
    [SerializeField] float jumpForce = 5f;


    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = playerBody.gravityScale;
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

        // Player is idling when not climbing

        animator.SetBool("IsClimbing", false);

        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            playerBody.gravityScale = gravityScaleAtStart;
            return;
        }

        hasVerticalSpeed = Mathf.Abs(playerBody.velocity.y) > Mathf.Epsilon;
        animator.SetBool("IsClimbing", hasVerticalSpeed);
        playerBody.velocity = new Vector2(playerBody.velocity.x, moveInput.y * climbSpeed);
        playerBody.gravityScale = 0;

        // Player climbing animation stops when not climbing

        // isClimbing = playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"));
        // animator.SetBool("IsClimbing", isClimbing);

        // if (isClimbing)
        // {
        //     Vector2 ClimbVelocity = new Vector2(playerBody.velocity.x, moveInput.y * climbSpeed);
        //     playerBody.velocity = ClimbVelocity;
        //     playerBody.gravityScale = 0;
        //     hasVerticalSpeed = Mathf.Abs(playerBody.velocity.y) > Mathf.Epsilon;
        //     animator.enabled = hasVerticalSpeed;;
        // }
        // else
        // {
        //     playerBody.gravityScale = gravityScaleAtStart;
        //     animator.enabled = true;
        // }
    }
}
