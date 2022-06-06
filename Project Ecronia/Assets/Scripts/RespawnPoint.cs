using UnityEngine;


public class RespawnPoint : MonoBehaviour
{
    Vector3 point;
    ParticleSystem particleeffect;

    private void Start()
    {
        point = gameObject.transform.position;
        particleeffect = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().SetRespanwPoint(this);
            PlayParticleEffect();
        }
    }

    public Vector3 GetSpawnPoint()
    {
        return point;
    }

    public void PlayParticleEffect()
    {
        particleeffect.Play();
    }
}
