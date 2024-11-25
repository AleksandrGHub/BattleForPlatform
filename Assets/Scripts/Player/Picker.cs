using UnityEngine;

public class Picker : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Resource resource))
        {
            if (resource is Coin)
            {
                Coin coin = (Coin)resource;
                coin.Release();
            }

            if (resource is AidKit)
            {
                AidKit aidKit= (AidKit)resource;
                _health.Increase(aidKit.Health);
                Destroy(collision.gameObject);
            }
        }
    }
}