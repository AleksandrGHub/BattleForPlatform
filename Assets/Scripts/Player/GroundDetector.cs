using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _overlapCircle;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radiusCircle;

    private int _minNumberCollisions = 1;

    public bool IsGround { get; private set; }

    private void FixedUpdate()
    {
        DetectCollisions();
    }

    private void DetectCollisions()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_overlapCircle.position, _radiusCircle, _layerMask);

        IsGround = colliders.Length >= _minNumberCollisions;
    }
}