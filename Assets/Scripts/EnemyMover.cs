using System.Linq;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Transform _way;
    [SerializeField] private float _speed;

    private Vector3[] _waypoints;
    private int _currentIndexWaypoint = 0;

    private void Start()
    {
        AddWaypoints();
        transform.position = _waypoints[_currentIndexWaypoint];
    }

    private void Update()
    {
        if (IsMinDistance())
        {
            Move(_playerPosition.position);
        }
        else
        {
            Move(GetWaypoint());
        }
    }

    private void AddWaypoints()
    {
        _waypoints = new Vector3[_way.childCount];

        for (int i = 0; i < _waypoints.Count(); i++)
        {
            _waypoints[i] = _way.GetChild(i).position;
        }
    }

    private void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private Vector3 GetWaypoint()
    {
        if (transform.position == _waypoints[_currentIndexWaypoint])
        {
            _currentIndexWaypoint = (++_currentIndexWaypoint) % _waypoints.Length;
        }

        return _waypoints[_currentIndexWaypoint];
    }

    private bool IsMinDistance()
    {
        float minTargetDistance = 1.8f;
        float targetDistance = Vector3.Distance(_playerPosition.position, transform.position);
        return targetDistance < minTargetDistance;
    }
}