using UnityEngine;

public class Picker : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Resource resource))
        {
            if (resource is Coin coin)
            {
                coin.Release();
            }

            if (resource is AidKit aidKit)
            {
                _health.Increase(aidKit.Health);
                Destroy(collision.gameObject);
            }
        }
    }
}