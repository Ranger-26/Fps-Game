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
        _audioSource.PlayOneShot(GunData.GunShootSounds[Random.Range(0, GunData.GunShootSounds.Length)]);
        if (Physics.Raycast(ray, out RaycastHit hit, GunData.Range))
        {
            Debug.Log("I hit something!");
            Instantiate(GunData.HitDecal, hit.transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(GunData.GunHitSounds[Random.Range(0, GunData.GunHitSounds.Length)]);
        }
    }
}