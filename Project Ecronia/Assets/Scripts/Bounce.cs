using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bounce : MonoBehaviour
{
    [SerializeField] float bounceForce = 10f;
    [SerializeField] Collider2D trigger;

    bool canBounce = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && canBounce)
        {
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounceForce)); 
        }
    }

    public void setBounce(bool state)
    {
        canBounce = state;
    }
}
