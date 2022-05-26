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
            Respawn();
    }
    public void OnHit(int damage)
    {
        if (onHitSound != null)
            audioManager.PlaySound(onHitSound);

        HitPoints -= damage;
    }

    public void OnDeath()
    {
        if (onDeathSound != null)
            StartCoroutine(audioManager.PlaySound(onDeathSound, 0.1f));


        if (gameObject.tag == "Player")
            Respawn();
        else
            Destroy(gameObject);
    }

    private void Respawn()
    {
        RespawnPoint temp = GetComponent<PlayerMovement>().GetRespawnPoint();
        if (temp != null)
        {
            transform.position = temp.GetSpawnPoint();
            GetComponent<PlayerMovement>().GetRespawnPoint().PlayParticleEffect();
        }
    }

}
