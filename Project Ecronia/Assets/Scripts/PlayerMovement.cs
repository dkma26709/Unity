using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] KeyCode jump;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode left;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float JumpForce = 10f;

    bool grounded = true;

    Rigidbody2D playerBody;
    private void Awake() 
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Jump();
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
        if (Input.GetKeyDown(jump) && grounded)
        {
            grounded = false;
            playerBody.AddForce(new Vector2(0, JumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }    
    }
}
