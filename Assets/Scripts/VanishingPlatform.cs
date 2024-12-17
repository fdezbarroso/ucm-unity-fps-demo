using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    [SerializeField]
    private float _timeActive = 3.0f;
    [SerializeField]
    private float _timeInactive = 3.0f;

    private Renderer _renderer = null;
    private Collider _collider = null;

    private float _timeRemaining = 0.0f;
    private bool _active = true;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider>();

        _timeRemaining = _timeActive;
    }

    private void Update()
    {
        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining <= 0.0f)
        {
            _active = !_active;
            _renderer.enabled = _active;
            _collider.enabled = _active;

            _timeRemaining = _active ? _timeActive : _timeInactive;
        }
    }
}
