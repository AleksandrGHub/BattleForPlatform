using UnityEngine;

public class Picker : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Release();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out AidKit aidKit))
        {
            _health.Increase(aidKit.Health);
            Destroy(collision.gameObject);
        }
    }
}