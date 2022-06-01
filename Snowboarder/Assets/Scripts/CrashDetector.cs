using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem CollisionEffect;
    [SerializeField] bool canCrash = true;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<Torque>().DisableControls();
            CollisionEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            if (canCrash)
            {
                Invoke("Restart",1.5f);
            }
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
