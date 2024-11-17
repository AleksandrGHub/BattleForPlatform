public class CharacterCombat : Combat
{
    private void Attack()
    {
        foreach (var collider in GetColliders2D())
        {
            if (collider.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);

                if (enemy.GetHealth() == 0)
                {
                    Destroy(enemy.gameObject);
                }
            }
        }
    }
}