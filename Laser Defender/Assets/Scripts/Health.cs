using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    public int GetHealth()
    {
        return health;
    }

    void OnTriggerEnter2D(Collider2D otherCollider) 
    {
        DamageDealer damageDealer = otherCollider.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }    
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
