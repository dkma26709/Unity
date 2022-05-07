using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Keys")]
    [SerializeField] KeyCode jump;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode changeForm;

    int currentForm = 0;

    // Values used in calculations
    float moveSpeed = 10f;
    float JumpForce = 10f;

    [Header("Form values")]
    // Form 0
    [SerializeField] float Form_0_MoveSpeed = 10f;
    [SerializeField] float Form_0_JumpForce = 10f;
    [SerializeField] float Form_0_GravityScale = 10f;
    [SerializeField] Vector3 Form_0_Scale;
    [SerializeField] Color Form_0_Color;

    // Form 1
    [SerializeField] float Form_1_MoveSpeed = 10f;
    [SerializeField] float Form_1_JumpForce = 1500f;
    [SerializeField] float Form_1_GravityScale = 10f;
    [SerializeField] Vector3 Form_1_Scale;
    [SerializeField] Color Form_1_Color;

    Rigidbody2D playerBody;
    Collider2D playercollider;
    SpriteRenderer spriteRenderer;



    private bool Grounded 
    { 
        get
        {
            return grounded;
        }
        set
        {
            if (value != grounded)
            {
                grounded = value;
            }
        } 
    }
    bool grounded = true;


    private void Awake() 
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        playercollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        ChangeFormValues(currentForm);
    }
    void Update()
    {
        Move();
        Jump();
        ChangeForm();
    }

    private void Move()
    {
        if (Input.GetKey(right))
        {
            playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
        }
        else if (Input.GetKey(left))
        {
            playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
        }
        else
        {
            playerBody.velocity = new Vector2(0,playerBody.velocity.y); 
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(jump) && Grounded)
        {
            Grounded = false;
            playerBody.AddForce(new Vector2(0, JumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player")
        {
            Grounded = true;
        }    
    }

    private void ChangeForm()
    {
        if (Input.GetKeyDown(changeForm))
        {
            currentForm++;
            if (currentForm > 1)
            {
                currentForm = 0;
            }
            ChangeFormValues(currentForm);
        }
    }

    private void ChangeFormValues(int index)
    {
        if (index == 0)
        {
            playerBody.gravityScale = Form_0_GravityScale;
            moveSpeed = Form_0_MoveSpeed;
            JumpForce = Form_0_JumpForce;
            this.transform.localScale = Form_0_Scale;
            spriteRenderer.color = Form_0_Color;
            SetBounce(false);
        }
        else if (index == 1)
        {
            playerBody.gravityScale = Form_1_GravityScale;
            moveSpeed = Form_1_MoveSpeed;
            JumpForce = Form_1_JumpForce;
            this.transform.localScale = Form_1_Scale;
            spriteRenderer.color = Form_1_Color;
            SetBounce(true);
        }
    }

    void SetBounce(bool state)
    {
        if (GetComponent<Bounce>() != null)
        {
            GetComponent<Bounce>().setBounce(state);
        }
    }



    // Small bug where if both players jump at same time, they stay together, meaning they won't re-collide with each other, and so won't reset their jumps.

    // Could be partially fixed, by using OnCollisionStay2D, but that makes the players able to double jump, presumably due to the players being in contact with the earth just as they jump,
    //resetting it. Furthermore, they would be able to infinitely jump, as long as they touch each other
}
