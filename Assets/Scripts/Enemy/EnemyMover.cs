using System.Linq;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _way;
    [SerializeField] private float _speed;
    [SerializeField] private DetectorPlayer _detectorPlayer;

    private Vector3[] _waypoints;
    private Vector3 _waypoint;
    private int _currentIndexWaypoint = 0;

    private void Awake()
    {
        AddWaypoints();
        transform.position = _waypoints[_currentIndexWaypoint];
    }

    private void FixedUpdate()
    {
        Move(_waypoint);
    }

    private void Update()
    {
        _waypoint = GetWaypoint();
    }

    public Vector3 GetDirection()
    {
        return _waypoint - transform.position;
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
        Vector3 waypoint;

        if (_detectorPlayer.PlayerCollider != null)
        {
            waypoint = _detectorPlayer.PlayerCollider.transform.position;
        }
        else
        {
            waypoint = _waypoints[_currentIndexWaypoint];

            if (transform.position == _waypoints[_currentIndexWaypoint])
            {
                _currentIndexWaypoint = (++_currentIndexWaypoint) % _waypoints.Length;
                waypoint = _waypoints[_currentIndexWaypoint];
            }
        }

        return waypoint;
    }
}