using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform cam;
    public Animator anim;
    public float fireRate = 0.2f;  // Delay between each shot
    public LayerMask targetLayers;  // Layers that the raycast should hit

    public GameObject impactEffect;

    private float nextFireTime = 0f;

    [Space]
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float bulletVelocity;
    public float bulletLifetime;
    public float gravity;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            anim.SetBool("Shooting", true);
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * bulletVelocity * 100, ForceMode.Force);
        Destroy(bullet, bulletLifetime);

        // Stop shooting animation
        StartCoroutine(StopShooting());
    }

    IEnumerator StopShooting()
    {
        yield return new WaitForSeconds(0.15f);
        anim.SetBool("Shooting", false);
    }
}
