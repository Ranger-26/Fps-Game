using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class GunShoot : MonoBehaviour
{
    public GunData GunData;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, GunData.Range))
        {
            GameObject decal = Instantiate(GunData.HitDecal, hit.point, Quaternion.identity);
            Destroy(decal, 3f);
        }
    }
}