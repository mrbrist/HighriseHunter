using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHit : ShootableObject
{
    public GameObject particlesPrefab;
    public override void OnHit(ContactPoint hit)
    {
        GameObject particles = Instantiate(particlesPrefab, hit.point + (hit.normal * 0.05f), Quaternion.LookRotation(hit.normal), transform.root.parent);
        ParticleSystem ps = particles.GetComponent<ParticleSystem>();

        if (ps)
        {
            var main = ps.main;
            main.startColor = Color.black;
        }

        Destroy(ps, 2f);
    }

    public override void OnHit(RaycastHit hit)
    {}
}
