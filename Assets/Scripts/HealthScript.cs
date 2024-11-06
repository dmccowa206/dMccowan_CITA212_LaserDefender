using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int hp = 50;
    [SerializeField] ParticleSystem hitFX;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitFX();
            damageDealer.Hit();
        }
    }
    public void TakeDamage(int dam)
    {
        hp -= dam;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void PlayHitFX()
    {
        if(hitFX != null)
        {
            ParticleSystem instance = Instantiate(hitFX, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
