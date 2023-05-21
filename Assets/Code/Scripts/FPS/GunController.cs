using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform cam;
    public float fireRate = 0.2f;  // Delay between each shot
    public float shootForce = 100f;  // Force applied to the bullet
    public LayerMask targetLayers;  // Layers that the raycast should hit

    private float nextFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, Mathf.Infinity, targetLayers))
        {
            // Perform actions based on the hit object (e.g., damage, effects)
            Destroy(hit.collider.gameObject);
        }

        // Spawn visual effects, play sound, etc.
        // Instantiate a bullet prefab or apply force to an existing projectile
    }
}
