using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileData : MonoBehaviour
{
    private int _damage = 0;
    private int _headMultiplier = 0;
    private int _shieldMultiplier = 0;

    public void SetData(int damage, int headMultiplier, int shieldMultiplier)
    {
        _damage = damage;
        _headMultiplier = headMultiplier;
        _shieldMultiplier = shieldMultiplier;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider hitCollider = collision.collider;

        Health health = hitCollider.GetComponentInParent<Health>();
        if (health != null)
        {
            int damage = _damage;
            if (hitCollider.CompareTag("Head"))
            {
                damage *= _headMultiplier;
            }
            else if (hitCollider.CompareTag("Shield"))
            {
                damage *= _shieldMultiplier;
            }
            health.Damage(damage);
        }
    }
}
