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
}
