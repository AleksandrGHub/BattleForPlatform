using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] Transform _overlapCircle;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] private float _radiusCircle = 0.3f;

    private int _minNumberCollisions = 1;

    public bool IsGround { get; private set; }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_overlapCircle.position, _radiusCircle);

        IsGround = colliders.Length > _minNumberCollisions;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(_overlapCircle.position, _radiusCircle);
    }
}