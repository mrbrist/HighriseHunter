using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitAllocation : MonoBehaviour
{
    public GameObject particlePrefab;
    public LayerMask terrain;
    public LayerMask enemies;

    GameObject[] FindGameObjectsInLayer(LayerMask layer)
    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        var goList = new List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((layer & 1 << goArray[i].layer) == 1 << goArray[i].layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
    }

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] es = FindGameObjectsInLayer(enemies);
        GameObject[] ts = FindGameObjectsInLayer(terrain);

        foreach (var e in es)
        {
            EnemyHit eh = e.AddComponent<EnemyHit>();
            eh.particlesPrefab = particlePrefab;

        }

        foreach (var t in ts)
        {
            t.AddComponent<TerrainHit>().particlesPrefab = particlePrefab;
        }
    }
}
