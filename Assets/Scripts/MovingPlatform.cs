using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _waypoint1 = null;
    [SerializeField]
    private Transform _waypoint2 = null;
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _distanceToStop = 2.0f;

    private Transform _currentWaypoint = null;
    private float _distanceToStopSqr = 0.0f;

    private void Start()
    {
        transform.position = _waypoint1.position;
        _currentWaypoint = _waypoint2;

        _distanceToStopSqr = _distanceToStop * _distanceToStop;
    }

    private void Update()
    {
        Vector3 dirToWaypoint = _currentWaypoint.position - transform.position;
        Vector3 dirToWaypointNormalized = dirToWaypoint.normalized;

        transform.position += dirToWaypointNormalized * _speed * Time.deltaTime;
        if (dirToWaypoint.sqrMagnitude <= _distanceToStopSqr)
        {
            _currentWaypoint = _currentWaypoint == _waypoint1 ? _waypoint2 : _waypoint1;
        }
    }
}
