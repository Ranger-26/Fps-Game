using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GunShoot : MonoBehaviour
{
    public GunData GunData;

    public UnityEvent OnGunShot;

    public UnityEvent OnGunDraw;

    public FirePoint FirePoint;

    private void Start()
    {
        if (FirePoint == null)
        {
            FirePoint = GetComponentInChildren<FirePoint>();
        }
    }

    private void Update()
    {
        if (GunData.FiringMode == FiringMode.SemiAuto)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                InvokeRepeating(nameof(Shoot), 0,  GunData.FireRate);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke(nameof(Shoot));
            }
        }
    }

    public void Shoot()
    {
        
    }
}