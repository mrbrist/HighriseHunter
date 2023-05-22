using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ShootableObject so;
        if (collision.collider.TryGetComponent(out so))
        {
            so.OnHit(collision.GetContact(0));
            Destroy(gameObject);
        }
    }
}
