using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log($"How dare you bump into {other.gameObject.name}");
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log($"You passed over {other.gameObject.name}");
    }
}
