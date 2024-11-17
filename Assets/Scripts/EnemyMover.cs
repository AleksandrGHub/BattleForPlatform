using System.Linq;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _way;
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusCircle;
    [SerializeField] private LayerMask _layerMask;

    private Vector3[] _waypoints;
    private Collider2D _playerCollider;
    private int _currentIndexWaypoint = 0;

    private void Awake()
    {
        AddWaypoints();
        transform.position = _waypoints[_currentIndexWaypoint];
    }

    private void FixedUpdate()
    {
        _playerCollider = Physics2D.OverlapCircle(transform.position, _radiusCircle, _layerMask);

        if (_playerCollider != null)
        {
            Move(_playerCollider.transform.position);
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
}