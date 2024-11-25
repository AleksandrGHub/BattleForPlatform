using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    protected float Damage = 40f;

    protected Collider2D[] GetColliders2D()
    {
        return Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);
    }
}