using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickupSound;
    [SerializeField] int Score = 10;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinPickupSound, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddScore(Score);
            Destroy(gameObject);
        }
    }
}
