using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    [SerializeField]
    private float _lifeTime = 5.0f;
    [SerializeField]
    private bool _destroyOnCollision = false;
    [SerializeField]
    private int _maxBounceCount = 1;

    //private float _remainingLifeTime = 0.0f;
    private int currentBounces = 0;

    private void Start()
    {
        // _remainingLifeTime = _lifeTime;

        Destroy(gameObject, _lifeTime);
    }

    //private void Update()
    //{
    //    _remainingLifeTime -= Time.deltaTime;

    //    if (_remainingLifeTime < 0.0f)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (_destroyOnCollision && currentBounces == _maxBounceCount)
        {
            Destroy(gameObject);
        }

        currentBounces++;
    }
}
