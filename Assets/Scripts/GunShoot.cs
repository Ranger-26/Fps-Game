using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GunData GunData;

    private AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
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
                InvokeRepeating(nameof(Shoot), 0f, GunData.FireRate);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke(nameof(Shoot));
            }
        }
    }

    void Shoot()
    {
        _source.PlayOneShot(GunData.GetRandomShootSound());
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, GunData.Range))
        {
            GameObject decal = Instantiate(GunData.HitDecal, hit.point, Quaternion.identity);
            _source.PlayOneShot(GunData.GetRandomHitSound());
            Destroy(decal, 3f);
        }
    }
}
