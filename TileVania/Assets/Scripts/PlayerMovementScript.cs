using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D playerBody;
    CapsuleCollider2D playerCollider;
    BoxCollider2D playerFeetCollider;
    Animator animator;
    PlayerInput playerInput;
    bool hasHorizontalSpeed;
    bool hasVerticalSpeed;
    bool isClimbing;
    bool isAlive;
    float gravityScaleAtStart;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float climbSpeed = 10f;
    [SerializeField] float jumpForce = 5f;

    private void Awake() 
    {
        playerBody = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        playerInput = GetComponent<PlayerInput>();
        isAlive = true;
    }

    void Start()
    {
        gravityScaleAtStart = playerBody.gravityScale;
    }

    void Update()
    {
        if (!isAlive)
            return;

        Run();
        Climb();
        FlipSprite();
    }

    void OnMove(InputValue inputValue)
    {
        if (!isAlive)
            return;

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
        if (inputValue.isPressed && playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))//playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
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

    private void OnCollisionEnter2D(Collision2D collider) 
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")) && isAlive)
        {
            Die();
            playerBody.drag = 2;
            playerBody.velocity = new Vector2(Mathf.Sign(collider.relativeVelocity.x) * 5, 10);
        }
    }

    void Die() 
    {
        isAlive = false;
        playerInput.DeactivateInput();
        animator.SetTrigger("Dying");
        GetComponent<SpriteRenderer>().color = new Color(0.5f,0.5f,0.5f,1);
        Invoke("Reload", 1f);
    }

    void Reload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
