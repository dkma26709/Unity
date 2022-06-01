using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    [SerializeField] float BounceForce = 1000;
    Rigidbody2D rb2d; 

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            rb2d.AddForce(new Vector2(0,BounceForce));
        }
        else
        {
            rb2d.AddForce(other.rigidbody.velocity*other.otherRigidbody.mass);
        }
    }

    

}
