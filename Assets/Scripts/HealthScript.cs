using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int hp = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitFX;
    CameraShake camShake;
    [SerializeField] bool applyCamShake;
    AudioPlayer audioPlayer;
    Scorekeeper scoreKeep;
    public int GetHealth()
    {
        return hp;
    }
    void Awake()
    {
        camShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeep = FindObjectOfType<Scorekeeper>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitFX();
            audioPlayer.PlayDamageClip();
            ShakeCam();
            damageDealer.Hit();
        }
    }
    public void TakeDamage(int dam)
    {
        hp -= dam;
        if(hp <= 0)
        {
            Die();
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
    void ShakeCam()
    {
        if(camShake != null && applyCamShake)
        {
            camShake.Play();
        }
    }
    void Die()
    {
        if (!isPlayer)
        {
            scoreKeep.ChangeScore(score);
        }
        Destroy(gameObject);
        
    }
}
