using UnityEngine;
using UnityEngine.InputSystem;

public class ScooterMoveScript : MonoBehaviour
{
    [SerializeField]
    private Scooter _scooter;

    [SerializeField]
    private Rigidbody _rigidbody;

    private Vector3 _input;

    private void FixedUpdate()
    {
        //transform.position += _input * Time.deltaTime;
        //transform.Translate(_input * Time.deltaTime * _scooter.Speed, Space.Self);
        //_rigidbody.AddForce(_input * Time.deltaTime * _scooter.Speed * 10);
        _rigidbody.MovePosition(transform.position + (new Vector3(_input.x, 0, 1) * Time.deltaTime * _scooter.Speed));
        //_rigidbody.velocity += _input * Time.deltaTime * _scooter.Speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector3>();
    }
}
