using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask collateralLayer;
    private void OnCollisionEnter(Collision collision)
    {
        ShootableObject so;
        if (collision.collider.TryGetComponent(out so))
        {
            ContactPoint contact = collision.GetContact(0);
            GetComponent<Rigidbody>().isKinematic = true;
            so.OnHit(contact);

            RaycastHit[] hits;
            hits = Physics.RaycastAll(contact.point, -contact.normal, Mathf.Infinity, collateralLayer);
            Debug.DrawRay(contact.point, -contact.normal, Color.red, 5f);

            if (hits.Length > 0) {
                foreach (var hit in hits)
                {
                    ShootableObject soCollateral;
                    if (hit.collider.TryGetComponent(out soCollateral))
                    {
                        soCollateral.OnHit(hit);
                    }
                }
            } else
            {
                Destroy(gameObject);
            }
        }
        Destroy(gameObject);
    }
}
