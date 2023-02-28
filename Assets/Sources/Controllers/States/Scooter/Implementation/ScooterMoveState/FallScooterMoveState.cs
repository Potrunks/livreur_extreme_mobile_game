using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Messages;
using Assets.Sources.Referentiel.Reference;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Controllers.States.Scooter.Implementation
{
    public class FallScooterMoveState : ScooterMoveState
    {
        public FallScooterMoveState()
        {
            _possibleStateByAction = new Dictionary<ScooterAction, IScooterMoveState>();
        }

        public override IScooterMoveState CheckStateChange(ScooterMoveComponent component)
        {
            if (_nextState != null)
            {
                return _nextState;
            }

            if (component._isGrounding)
            {
                return new GoForwardScooterMoveState();
            }

            return null;
        }

        public override void OnEnter(ScooterMoveComponent component)
        {
            
        }

        public override void OnExit(ScooterMoveComponent component)
        {
            component._scooterRigidbody.useGravity = true;
            component._scooterRigidbody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        public override void OnFixedUpdate(ScooterMoveComponent component)
        {
            component._scooterRigidbody.MovePosition(component.transform.position + (new Vector3(0, PhysicValuesReference.FALL_Y_DIRECTION, component._scooterParameters.Speed) * Time.deltaTime));
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
