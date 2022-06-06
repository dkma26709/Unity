using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Teleporter connectedTeleporter;

    bool isActive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isActive)
        {
            StartCoroutine(connectedTeleporter.TemporarilyDisableTeleporter(1f));
            collision.gameObject.transform.position = connectedTeleporter.gameObject.transform.position;
        }
    }

    public IEnumerator TemporarilyDisableTeleporter(float delay)
    {
        isActive = false;
        yield return new WaitForSecondsRealtime(delay);
        isActive = true;
    }
}
