using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootClip;
    [SerializeField] [Range(0f, 1f)] float shootVol = 1f;
    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damVol = 1f;

    public void PlayShootingClip()
    {
        PlayClip(shootClip,shootVol);
    }
    public void PlayDamageClip()
    {
        PlayClip(damageClip,damVol);
    }
    public void PlayClip(AudioClip soundClip, float vol)
    {
        if(soundClip != null)
        {
            AudioSource.PlayClipAtPoint(soundClip, Camera.main.transform.position, vol);
        }
    }
}
