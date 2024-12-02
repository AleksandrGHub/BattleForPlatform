using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] protected float Damage = 40f;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    protected Collider2D[] GetColliders2D()
    {
        return Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);
    }
}