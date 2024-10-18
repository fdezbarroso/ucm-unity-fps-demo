using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Common")]
    [SerializeField]
    private Rigidbody _projectileRb = null;
    [SerializeField]
    private Transform _projectileSpawnpoint = null;
    [SerializeField]
    private AudioClip _audioClip = null;
    [SerializeField]
    private float _delayBetweenShots = 1.0f;
    [SerializeField]
    private int _ammo = 0;
    [SerializeField]
    private int _maxAmmo = 1;
    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private int _headMultiplier = 2;
    [SerializeField]
    private int _shieldMultiplier = 0;

    [Header("Projectile")]
    [SerializeField]
    private float _projectileSpeed = 1.0f;

    [Header("Instant Shoot")]
    [SerializeField] private ParticleSystem _instantShootParticles = null;
    [SerializeField] private float _instantShootForce = 100.0f;
    [SerializeField] private float _instantShootRange = 100.0f;

    private float _remainingTimeBetweenShots = 0.0f;

    private void Start()
    {
        _ammo = _maxAmmo;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _remainingTimeBetweenShots <= 0.0f && _ammo > 0)
        {
            if (_projectileRb != null)
            {
                ShootProjectile();
            }
            else
            {
                ShootInstant();
            }

            AudioSource.PlayClipAtPoint(_audioClip, transform.position);
            _remainingTimeBetweenShots = _delayBetweenShots;
            _ammo--;

            return;
        }
        _remainingTimeBetweenShots = Mathf.Max(_remainingTimeBetweenShots - Time.deltaTime, 0.0f);
    }

    private void ShootProjectile()
    {
        Rigidbody projectile = Instantiate(_projectileRb, _projectileSpawnpoint.position, Quaternion.identity);
        if (projectile != null)
        {
            ProjectileData projectileData = projectile.GetComponent<ProjectileData>();
            if (projectileData != null)
            {
                projectileData.SetData(_damage, _headMultiplier, _shieldMultiplier);
            }

            projectile.velocity = _projectileSpawnpoint.forward * _projectileSpeed;
        }
    }

    private void ShootInstant()
    {
        if (Physics.Raycast(_projectileSpawnpoint.position, _projectileSpawnpoint.forward, out RaycastHit hit, _instantShootRange))
        {
            Instantiate(_instantShootParticles, hit.point, Quaternion.identity);

            Collider hitCollider = hit.collider;

            Rigidbody rb = hitCollider.attachedRigidbody;
            if (rb != null && !rb.isKinematic)
            {
                rb.AddExplosionForce(_instantShootForce, hit.point, 1.0f);
            }

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

}
