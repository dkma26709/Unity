using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myrigidBody;

    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float scale = 0.5f;

    float xSpeed;
    float direction;

    PlayerMovementScript player;

    void Start()
    {
        myrigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovementScript>();

        direction = Mathf.Sign(player.transform.localScale.x);
        xSpeed =  direction*bulletSpeed;

        myrigidBody.transform.localScale = new Vector3(scale*direction,scale,scale);

    }

    void Update()
    {
        myrigidBody.velocity = new Vector2(xSpeed, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
