using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Controllers.States.Scooter.Implementation;
using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ScooterMoveComponent : MoveComponent
{
    [Header("Entity")]
    public Scooter _scooterParameters;

    [Header("Required Component")]
    public Rigidbody _scooterRigidbody;

    [Header("Parameters")]
    [Header("Jump")]
    public float _jumpLimitYPosition = 7;
    public float _jumpXRotation = -20;
    [Tooltip("Duration in second")]
    public float _jumpRotationDuration = 0.1f;
    [Header("Swipe")]
    public float _swipeLeftZRotation = 10;
    public float _swipeRightZRotation = -10;
    [Tooltip("Duration in second")]
    public float _swipeRotationDuration = 0.25f;
    [Tooltip("Duration in second")]
    public float _swipeRotationRecoveryDuration = 0.1f;

    private IScooterMoveState _currentState;
    private IScooterMoveState _nextState;
    public IScooterBusiness _scooterBusiness;

    [HideInInspector]
    public RoadColumnPosition _currentColumn;
    [HideInInspector]
    public float _currentJumpLimitYPosition;

    private void Awake()
    {
        _currentState = new GoForwardScooterMoveState();
        _currentColumn = RoadColumnPosition.MIDDLE;
        _scooterBusiness = new ScooterBusiness();
    }

    private void Update()
    {
        _nextState = _currentState.CheckStateChange(this);
        if (_nextState != null)
        {
            _currentState.OnExit(this);
            _currentState = _nextState;
            _currentState.OnEnter(this);
        }
    }

    private void LateUpdate()
    {
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
        _scooterBusiness.DoSwipe(context.ReadValue<Vector2>(), _currentColumn, _currentState, _isGrounding);
    }
}
