using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Player _player;

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Enemy enamy))
            {
                enamy.TakeDamage(_player.Damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y), _radius);
    }
}