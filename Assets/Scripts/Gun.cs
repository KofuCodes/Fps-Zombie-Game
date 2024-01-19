using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 5f;
    public float impactForce = 30f;
    public int magAmmo = 8;
    public int reloadTime = 2;

    public GameObject ammoCount;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0;
    private int ammo = 0;
    [SerializeField] float timerAmount = 10;
    private float reloadTimer = 0;

    void Start()
    {
        ammo = magAmmo;
        reloadTimer = timerAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadTimer >= timerAmount)
        {
            reloadTimer = timerAmount;
        } else
        {
            reloadTimer += Time.deltaTime;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if (ammo > 0)
            {
                ammo--;
                ammoCount.GetComponent<TMP_Text>().text = $"{ammo}";
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }

        if (Input.GetKey(KeyCode.R) && ammo < 12 && reloadTimer >= timerAmount)
        {
            reloadTimer = 0;
            ammo = magAmmo;
            ammoCount.GetComponent<TMP_Text>().text = $"{ammo}";
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

        }
    }

}
