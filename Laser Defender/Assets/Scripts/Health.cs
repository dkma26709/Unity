using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] ParticleSystem hit;

    CameraShake mainCamera;
    AudioPlayer audioPlayer;

    void Awake() {
        
    }

    private void Start() 
    {
        mainCamera = FindObjectOfType<CameraShake>();
    }

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
            PlayHitEffect();
            damageDealer.Hit();
        }    
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (gameObject.tag == "Player")
        {
            mainCamera.Play();
            

        }
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayExplosionEffect();
        Destroy(gameObject);
    }

    void PlayExplosionEffect()
    {
        if (explosion != null)
        {
            ParticleSystem instance = Instantiate(explosion, transform.position, Quaternion.identity);
            instance.Play();
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void PlayHitEffect()
    {
        if (explosion != null)
        {
            ParticleSystem instance = Instantiate(hit, transform.position, Quaternion.identity);
            instance.Play();
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
