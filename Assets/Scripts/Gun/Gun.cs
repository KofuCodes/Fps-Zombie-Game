using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 5f;
    public float impactForce = 30f;
    public int magAmmo = 8;
    public float reloadTime = 1f;

    public GameObject ammoCount;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject Head;
    AudioSource gunSound;

    private float nextTimeToFire = 0;
    private int ammo = 0;
    private PlayerStats stats;
    private bool isReloading = false;
    public Animator anim;

    void Start()
    {
        stats = GetComponentInParent<PlayerStats>();
        ammo = magAmmo;
        gunSound = GetComponentInParent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!stats.IsDead())
        {
            if (isReloading)
            {
                return;
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

            if (Input.GetKey(KeyCode.R) && ammo < 12 && !isReloading)
            {
                StartCoroutine(Reload());
            }

            if (ammo <= 0)
            {
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        anim.SetBool("reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);
        anim.SetBool("reloading", false);
        yield return new WaitForSeconds(.25f);
        ammo = magAmmo;
        ammoCount.GetComponent<TMP_Text>().text = $"{ammo}";
        isReloading= false;
    }

    void Shoot()
    {
        muzzleFlash.Play();
        gunSound.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponentInParent<Enemy>(); // Use GetComponentInParent to find the Enemy script on the parent object
            if (target != null)
            {
                if (hit.transform.gameObject == Head)
                {
                    target.TakeDamage(damage * 3); // Triple damage for headshot doesn't work
                }
                else
                {
                    target.TakeDamage(damage); // Normal damage for body shots
                }
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
