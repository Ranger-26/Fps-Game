using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Item")]
public class GunData : ScriptableObject
{
    public float Range;

    public FiringMode FiringMode;

    public float FireRate;

    public GameObject HitDecal;

    public AudioClip[] shootSounds;

    public AudioClip[] hitSounds;

    public AudioClip GetRandomShootSound()
    {
        return shootSounds[Random.Range(0, shootSounds.Length)];
    }

    public AudioClip GetRandomHitSound()
    {
        return shootSounds[Random.Range(0, hitSounds.Length)];
    }
}
