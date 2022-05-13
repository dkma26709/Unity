using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] KeyCode respawnKey;

    [SerializeField] int HitPoints;

    [SerializeField] AudioClip onHitSound;
    [SerializeField] AudioClip onDeathSound;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(respawnKey))
        {
            Respawn();
        }
    }
    public void OnHit(int damage) 
    {
        audioManager.PlaySound(onHitSound);
        HitPoints -= damage;
    }

    public void OnDeath()
    {
        StartCoroutine(audioManager.PlaySound(onDeathSound, 0.1f));
        

        if (gameObject.tag == "Player")
        {
            Respawn();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Respawn()
    {
        transform.position = GetComponent<PlayerMovement>().GetRespawnPoint().GetSpawnPoint();
        GetComponent<PlayerMovement>().GetRespawnPoint().PlayParticleEffect();
    }

}
