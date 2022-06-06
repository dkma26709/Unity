using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;

    Coroutine shake;


    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        if (shake == null)
        {
            shake = StartCoroutine(Shake());
        }

    }

    IEnumerator Shake()
    {
        float timeElapsed = 0;

        while (shakeDuration > timeElapsed)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
        shake = null;
    }


}
