using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Messages;
using UnityEngine;

namespace Assets.Sources.Controllers.States.Scooter.Implementation
{
    public class SwipeLeftScooterMoveState : ScooterMoveState
    {
        public override IScooterMoveState CheckStateChange(ScooterMoveComponent component)
        {
            if (_nextState != null)
            {
                return _nextState;
            }

            if ((component._currentColumn == RoadColumnPosition.MIDDLE && component.transform.position.x <= -3)
                || (component._currentColumn == RoadColumnPosition.RIGHT && component.transform.position.x <= 0))
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
            if (component._currentColumn == RoadColumnPosition.MIDDLE)
            {
                component._currentColumn = RoadColumnPosition.LEFT;
            }
            else if (component._currentColumn == RoadColumnPosition.RIGHT)
            {
                component._currentColumn = RoadColumnPosition.MIDDLE;
            }
        }

        public override void OnFixedUpdate(ScooterMoveComponent component)
        {
            component._scooterRigidbody.MovePosition(component.transform.position + (new Vector3(-1 * component._scooterParameters.DodgeSpeed, 0, 1) * Time.deltaTime * component._scooterParameters.Speed));
        }

        public override void OnPlayerInput(ScooterAction action)
        {
            switch (action)
            {
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
