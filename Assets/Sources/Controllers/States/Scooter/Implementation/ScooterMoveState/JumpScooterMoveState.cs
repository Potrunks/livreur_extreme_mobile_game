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

            if (component.transform.position.y >= component._yPositionJumpLimit)
            {
                Debug.Log("Fall State");
            }

            return null;
        }

        public override void OnEnter(ScooterMoveComponent component)
        {
            component._yPositionJumpLimit = component.transform.position.y + PhysicValuesReference.JUMP_LIMIT_Y_POSITION;
            component._scooterRigidbody.useGravity = false;
            component._scooterRigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            component.transform.DORotate(new Vector3(PhysicValuesReference.JUMP_X_ROTATION, 0, 0), PhysicValuesReference.JUMP_X_ROTATION_DURATION);
        }

        public override void OnExit(ScooterMoveComponent component)
        {
            
        }

        public override void OnFixedUpdate(ScooterMoveComponent component)
        {
            component._scooterRigidbody.MovePosition(component.transform.position + (new Vector3(0, component._scooterParameters.JumpSpeed, component._scooterParameters.Speed) * Time.deltaTime));
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
