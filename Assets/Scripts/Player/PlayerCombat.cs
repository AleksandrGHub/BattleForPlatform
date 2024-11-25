public class PlayerCombat : Combat
{
    private void Attack()
    {
        foreach (var collider in GetColliders2D())
        {
            if (collider.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(Damage);

                if (enemy.GetHealth() == 0)
                {
                    Destroy(enemy.gameObject);
                }
            }
        }
    }
}