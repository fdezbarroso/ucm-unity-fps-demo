using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float _timeToOpen = 3.0f;
    [SerializeField] private float _speed = 8.0f;

    private float _timeRemaining;

    private void Update()
    {
        if (_timeRemaining <= 0f)
        {
            return;
        }

        transform.position += Time.deltaTime * _speed * transform.up;
        _timeRemaining -= Time.deltaTime;
    }

    public void Open()
    {
        _timeRemaining = _timeToOpen;
    }
}
