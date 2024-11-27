using UnityEngine;

public class DetectorPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radiusCircle;

    public Collider2D PlayerCollider { get; private set; }

    private void FixedUpdate()
    {
        PlayerCollider = Physics2D.OverlapCircle(transform.position, _radiusCircle, _layerMask);
    }
}