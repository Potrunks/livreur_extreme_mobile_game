using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [Header("Runtime Values")]
    public bool _isGrounding;

    [Header("Required Component")]
    public Rigidbody _scooterRigidbody;
}
