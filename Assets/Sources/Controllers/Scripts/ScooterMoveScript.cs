using UnityEngine;

public class ScooterMoveScript : MonoBehaviour
{
    [SerializeField]
    private Scooter _scooter;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _scooter.Speed);
    }
}
