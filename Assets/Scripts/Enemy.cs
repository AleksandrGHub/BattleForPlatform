using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private float _damage = 20;
    private float _health = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);

            Debug.Log(player.Health);
        }
    }

    public void TakeDamage(float damage)
    {
        float minHealth = 0;

        if (_health > minHealth)
        {
            _health -= damage;
        }

        if (_health <= minHealth)
        {
            _health = 0;
            _spawner.Spawn();
            Destroy(gameObject);
        }

        Debug.Log($"Çהמנמגüו גנאדא: {_health}");
    }
}