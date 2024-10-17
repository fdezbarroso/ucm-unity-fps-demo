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

    [Header("Projectile")]
    [SerializeField]
    private float _projectileSpeed = 1.0f;

    [Header("Instant Shoot")]
    [SerializeField] private ParticleSystem _instantShootParticles = null;
    [SerializeField] private float _instantShootForce = 100.0f;
    [SerializeField] private float _instantShootRange = 100.0f;

    private float _remainingTimeBetweenShots = 0.0f;

    private void Update()
    {
        if (Input.GetMouseButton(0) && _remainingTimeBetweenShots <= 0.0f)
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
            return;
        }
        _remainingTimeBetweenShots = Mathf.Max(_remainingTimeBetweenShots - Time.deltaTime, 0.0f);
    }

    private void ShootProjectile()
    {
        Rigidbody projectile = Instantiate(_projectileRb, _projectileSpawnpoint.position, Quaternion.identity);
        if (projectile != null)
        {
            projectile.velocity = _projectileSpawnpoint.forward * _projectileSpeed;
        }
    }

    private void ShootInstant()
    {
        if (Physics.Raycast(_projectileSpawnpoint.position, _projectileSpawnpoint.forward, out RaycastHit hit, _instantShootRange))
        {
            Instantiate(_instantShootParticles, hit.point, Quaternion.identity);
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null && !rb.isKinematic)
            {
                rb.AddExplosionForce(_instantShootForce, hit.point, 1.0f);
            }
        }
    }

}
