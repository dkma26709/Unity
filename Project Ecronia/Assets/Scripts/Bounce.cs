using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bounce : MonoBehaviour
{
    [SerializeField] float bounceForce = 10f;
    [SerializeField] Collider2D trigger;

    [SerializeField] AudioClip BounceSound;

    AudioManager audioManager;

    bool canBounce = false;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && canBounce)
        {
            audioManager.PlaySound(BounceSound);
            Rigidbody2D player = collider.gameObject.GetComponent<Rigidbody2D>();
            player.velocity = Vector2.zero;
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounceForce)); 
        }
    }

    public void setBounce(bool state)
    {
        canBounce = state;
    }
}
