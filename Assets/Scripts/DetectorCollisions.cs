using UnityEngine;

public class DetectorCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CoinSpawner coinSpawner) && coinSpawner.CanSpawn)
        {
            coinSpawner.Spawn();
        }
    }
}