using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHit : ShootableObject
{
    public GameObject particlesPrefab;
    public override void OnHit(RaycastHit hit)
    {
        GameObject particles = Instantiate(particlesPrefab, hit.point + (hit.normal * 0.05f), Quaternion.LookRotation(hit.normal), transform.root.parent);
        ParticleSystem ps = particles.GetComponent<ParticleSystem>();
        MeshRenderer mr = GetComponent<MeshRenderer>();

        if (ps && mr)
        {
            ps.startColor = mr.material.color;
        }

        Destroy(ps, 2f);
    }
}
