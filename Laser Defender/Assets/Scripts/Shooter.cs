using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;

    [Header("Fire Rate")]
    [SerializeField] float baseFireRate = 0.3f;
    [SerializeField] float fireRateVariance = 0f;
    [SerializeField] float minimumfireRate = 0.2f;

    Coroutine firingCoroutine;

    public bool isFiring;
    void Start()
    {

    }

    void Update()
    {
        if (isFiring && firingCoroutine == null)
        {
            Fire();
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    void Fire()
    {
        firingCoroutine = StartCoroutine(FireContinously());
    }

    IEnumerator FireContinously()
    {
        while (isFiring)
        {
            GameObject tempProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            tempProjectile.GetComponent<Rigidbody2D>().velocity = transform.up * projectileSpeed;
            Destroy(tempProjectile, projectileLifeTime);

            yield return new WaitForSecondsRealtime(GetRandomFireRate());
        } 
    }

    float GetRandomFireRate()
    {
        if (fireRateVariance != 0)
        {
            float tempNumber = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
            return Mathf.Clamp(tempNumber ,minimumfireRate, float.MaxValue);
        }
        return baseFireRate;
    }
}
