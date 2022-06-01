using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] int NextLevel = 0;
    [SerializeField] float delayTime = 1.5f;
    [SerializeField] ParticleSystem FinishEffect;

        private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            FinishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("Restart",delayTime);
        }
    }
        void Restart(){
            SceneManager.LoadScene(NextLevel);
    }
}
