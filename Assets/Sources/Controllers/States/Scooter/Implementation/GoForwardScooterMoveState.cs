using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Messages;
using UnityEngine;

namespace Assets.Sources.Controllers.States.Scooter.Implementation
{
    public class GoForwardScooterMoveState : ScooterMoveState
    {
        public override IScooterMoveState CheckStateChange(ScooterMoveComponent component)
        {
            if (_nextState != null)
            {
                return _nextState;
            }

            return null;
        }

        public override void OnEnter(ScooterMoveComponent component)
        {
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
            switch (action)
            {
                case ScooterAction.SWIPE_RIGHT:
                    _nextState = new SwipeRightScooterMoveState();
                    break;
                default:
                    Debug.LogWarning(string.Format(StateMessages.NOT_EXISTS_ACTION, action, this.GetType().Name));
                    break;
            }
        }

        public override void OnUpdate(ScooterMoveComponent component)
        {
        }
    }
}
