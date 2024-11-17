using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AidKit : MonoBehaviour
{
    public float Health { get; private set; } = 30;
}