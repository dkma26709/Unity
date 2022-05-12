using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] int HitPoints;

    [SerializeField] AudioClip onHitSound;
    [SerializeField] AudioClip onDeathSound;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnHit(int damage) 
    {
        audioManager.PlaySound(onHitSound);
        HitPoints -= damage;
    }

    void OnDeath()
    {
        audioManager.PlaySound(onDeathSound);
        Destroy(gameObject);
    }
}
