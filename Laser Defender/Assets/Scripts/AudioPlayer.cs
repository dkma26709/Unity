using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource source;

    [Header("Enemies")] 
    [SerializeField] AudioClip enemyExplosionSFX;
    [SerializeField] AudioClip enemyShootingSFX;
    [SerializeField] AudioClip enemyHitSFX;

    [Header("Player")] 
    [SerializeField] AudioClip playerHitSFX;
    [SerializeField] AudioClip playerShootingSFX;
    [SerializeField] AudioClip playerdeathSFX;

    void Awake() 
    {
        source = FindObjectOfType<Camera>().GetComponent<AudioSource>();    
    }

    public void PlayerHit()
    {
        AudioSource.PlayClipAtPoint(playerHitSFX, Camera.main.transform.position);
    }

    public void PlayerDeath()
    {
        AudioSource.PlayClipAtPoint(playerdeathSFX, Camera.main.transform.position);
    }

    public void Shoot(string tag)
    {
        switch (tag)
        {
            case tag == "player"; ;
            default:
        }
            AudioSource.PlayClipAtPoint(playerShootingSFX, Camera.main.transform.position);
    }

    public void EnemyHit()
    {

    }

    public void EnemyDeath()
    {

    }
}
