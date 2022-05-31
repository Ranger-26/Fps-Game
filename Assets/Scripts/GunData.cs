using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Item")]
public class GunData : ScriptableObject
{
    public AudioClip[] GunShootSounds;

    public AudioClip[] GunHitSounds;

    public float Range;

    public FiringMode FiringMode;

    public float FireRate;
}
