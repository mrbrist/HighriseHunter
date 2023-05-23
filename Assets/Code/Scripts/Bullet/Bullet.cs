using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask collateralLayer;

    private Rigidbody rb;
    private Vector3 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        velocity = -rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ShootableObject so;
        if (collision.collider.TryGetComponent(out so))
        {
            ContactPoint contact = collision.GetContact(0);
            GetComponent<Rigidbody>().isKinematic = true;
            so.OnHit(contact);

            RaycastHit[] hits;
            hits = Physics.RaycastAll(contact.point, contact.normal - velocity, Mathf.Infinity, collateralLayer);
            Debug.DrawRay(contact.point, contact.normal - velocity, Color.red, 5f);

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
