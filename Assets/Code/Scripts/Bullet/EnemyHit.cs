using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : ShootableObject
{
    public GameObject particlesPrefab;

    public override void OnHit(ContactPoint hit)
    {
        GameObject particles = Instantiate(particlesPrefab, hit.point + (hit.normal * 0.05f), Quaternion.LookRotation(hit.normal), transform.root.parent);

        SpawnParticles(particles);
    }

    public override void OnHit(RaycastHit hit)
    {
        GameObject particles = Instantiate(particlesPrefab, hit.point + (hit.normal * 0.05f), Quaternion.LookRotation(hit.normal), transform.root.parent);

        SpawnParticles(particles);
    }

    void SpawnParticles (GameObject particles)
    {
        ParticleSystem ps = particles.GetComponent<ParticleSystem>();

        if (ps)
        {
            var main = ps.main;
            main.startColor = Color.red;
        }

        Destroy(particles, 2f);
    }
}
