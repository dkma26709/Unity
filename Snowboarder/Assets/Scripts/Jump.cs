using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] float jumpForce = 1000;
    Rigidbody2D rb2d;
    bool grounded = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {

        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && grounded && FindObjectOfType<Torque>().canMove)
        {
            grounded = false;
            //Debug.Log(grounded);
            rb2d.AddForce(new Vector2(0,jumpForce));
            GetComponent<AudioSource>().PlayOneShot(jumpSFX);
        }
    }
}
