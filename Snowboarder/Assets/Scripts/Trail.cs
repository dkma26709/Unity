using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField] ParticleSystem TrailEffect;
    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            TrailEffect.Stop();
        }
    }

        void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            TrailEffect.Play();
        }
    }
}
