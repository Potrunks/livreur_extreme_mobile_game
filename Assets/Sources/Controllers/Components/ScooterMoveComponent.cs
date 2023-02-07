using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Controllers.States.Scooter.Implementation;
using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScooterMoveComponent : MonoBehaviour
{
    [Header("Entity")]
    public Scooter _scooterParameters;

    [Header("Required Component")]
    public Rigidbody _scooterRigidbody;

    private IScooterMoveState _currentState;
    private IScooterMoveState _nextState;
    private IScooterBusiness _scooterBusiness;

    [HideInInspector]
    public RoadColumnPosition _currentColumn;

    private void Awake()
    {
        _currentState = new GoForwardScooterMoveState();
        _currentColumn = RoadColumnPosition.MIDDLE;
        _scooterBusiness = new ScooterBusiness();
    }

    private void Update()
    {
        _nextState = _currentState.CheckStateChange(this);
        if (_nextState != null )
        {
            _currentState.OnExit(this);
            _currentState = _nextState;
            _currentState.OnEnter(this);
        }
        _currentState.OnUpdate(this);
    }

    private void FixedUpdate()
    {
        _currentState.OnFixedUpdate(this);

        //transform.position += _input * Time.deltaTime;
        //transform.Translate(_input * Time.deltaTime * _scooter.Speed, Space.Self);
        //_rigidbody.AddForce(_input * Time.deltaTime * _scooter.Speed * 10);
        //_rigidbody.velocity += _input * Time.deltaTime * _scooter.Speed;
        //_scooterRigidbody.MovePosition(transform.position + (Vector3.forward * Time.deltaTime * _scooterParameters.Speed));
    }

    public void OnSwipeInput(InputAction.CallbackContext context)
    {
        _scooterBusiness.DoSwipe(context.ReadValue<Vector3>().x, _currentColumn, _currentState);
    }
}
