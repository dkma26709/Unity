using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] int HitPoints;

    void OnHit(int damage) 
    {
        HitPoints -= damage;
    }

    void OnDeath()
    {
        Destroy(gameObject);
    }
}
