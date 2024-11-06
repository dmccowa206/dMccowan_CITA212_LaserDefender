using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpd = 11f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFireRate = 0.2f;
    [Header("AI")]
    [SerializeField] bool useAI;
    private float fireRateVariance = 0.7f;
    [SerializeField] float minFireRate = 0.8f;
    [HideInInspector]public bool isFiring;
    Coroutine fireCoroutine;
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }
    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpd;
            }
            Destroy(instance, projectileLifetime);
            if(useAI)
            {
                float fireRateAI = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
                baseFireRate = Mathf.Clamp(fireRateAI, minFireRate, float.MaxValue);
            }
            yield return new WaitForSeconds(baseFireRate);
        }
    }
}
