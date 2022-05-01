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

    // Small bug where if both players jump at same time, they stay together, meaning they won't re-collide with each other, and so won't reset their jumps.

    // Could be partially fixed, by using OnCollisionStay2D, but that makes the players able to double jump, presumably due to the players being in contact with the earth just as they jump,
    //resetting it. Furthermore, they would be able to infinitely jump, as long as they touch each other
}
