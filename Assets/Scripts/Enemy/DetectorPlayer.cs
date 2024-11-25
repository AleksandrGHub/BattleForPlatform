using UnityEngine;

public class DetectorPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radiusCircle;

    private Collider2D _playerCollider;

    private void FixedUpdate()
    {
        _playerCollider = Physics2D.OverlapCircle(transform.position, _radiusCircle, _layerMask);
    }

    public Collider2D GetPlayerCollider()
    {
        return _playerCollider;
    }
}