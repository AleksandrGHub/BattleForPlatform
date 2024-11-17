public class EnemyCombat : Combat
{
    private void OnTriggerEnter2D()
    {
        Attack();
    }

    private void Attack()
    {
        foreach (var collider in GetColliders2D())
        {
            if (collider.gameObject.TryGetComponent(out Player player))
            {
                player.TakeDamage(_damage);
            }
        }
    }
}