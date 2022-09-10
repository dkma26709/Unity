using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D enemyBody;
    BoxCollider2D sideCollider;
    private void Start() 
    {
        enemyBody = GetComponent<Rigidbody2D>();    
        sideCollider = GetComponent<BoxCollider2D>();    
    }

    private void Update() 
    {
        // transform.localScale = new Vector2(Mathf.Sign(enemyBody.velocity.x), 1f);
        // if (sideCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        // {
        //     moveSpeed = moveSpeed * -1;
        //     EnableSideCollider();
        //     //EnableSideCollider(true);
        //     Invoke("EnableSideCollider",0.5f);
        // }
        enemyBody.velocity = new Vector2(moveSpeed, enemyBody.velocity.y);    
    }

    void EnableSideCollider()
    {
        sideCollider.enabled = !sideCollider.enabled;
        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        FlipEnemy();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer ==  LayerMask.NameToLayer("Enemies"))
        {
            FlipEnemy();
        }    
    }

    void FlipEnemy()
    {
        EnableSideCollider();
        transform.localScale = new Vector2(-Mathf.Sign(enemyBody.velocity.x), 1f);
        moveSpeed = -moveSpeed;
        Invoke("EnableSideCollider",0.5f);
    }
}
