using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Messages;
using Assets.Sources.Referentiel.Reference;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Controllers.States.Scooter.Implementation
{
    public class JumpScooterMoveState : ScooterMoveState
    {
        public JumpScooterMoveState()
        {
            _possibleStateByAction = new Dictionary<ScooterAction, IScooterMoveState>();
        }

        public override IScooterMoveState CheckStateChange(ScooterMoveComponent component)
        {
            if (_nextState != null)
            {
                return _nextState;
            }

            if (component._scooterRigidbody.velocity.y <= PhysicValuesReference.VELOCITY_Y_LOW_THRESHOLD)
            {
                return new FallScooterMoveState();
            }

            return null;
        }

        public override void OnEnter(ScooterMoveComponent component)
        {
            component._scooterRigidbody.AddForce(Vector3.up * component._scooterParameters.JumpForce);
            component.transform.DORotate(new Vector3(PhysicValuesReference.ANGLE_X_ROTATION_JUMP, 0, 0), PhysicValuesReference.ANGLE_X_ROTATION_TIME_JUMP);
        }

        public override void OnExit(ScooterMoveComponent component)
        {
            
        }

        public override void OnFixedUpdate(ScooterMoveComponent component)
        {
            component._scooterRigidbody.MovePosition(component.transform.position + (Vector3.forward * Time.deltaTime * component._scooterParameters.Speed));
        }

        public override void OnPlayerInput(ScooterAction action)
        {
            if (!_possibleStateByAction.TryGetValue(action, out _nextState))
            {
                Debug.LogWarning(string.Format(StateMessages.NOT_EXISTS_ACTION, action, this.GetType().Name));
            }
        }

        public override void OnUpdate(ScooterMoveComponent component)
        {
            
        }
    }
}
