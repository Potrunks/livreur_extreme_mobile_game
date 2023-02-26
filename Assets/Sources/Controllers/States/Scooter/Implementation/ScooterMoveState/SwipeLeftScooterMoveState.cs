using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Messages;
using Assets.Sources.Referentiel.Reference;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Controllers.States.Scooter.Implementation
{
    public class SwipeLeftScooterMoveState : ScooterMoveState
    {
        public SwipeLeftScooterMoveState()
        {
            _possibleStateByAction = new Dictionary<ScooterAction, IScooterMoveState>();
        }

        public override IScooterMoveState CheckStateChange(ScooterMoveComponent component)
        {
            if (_nextState != null)
            {
                return _nextState;
            }

            if ((component._currentColumn == RoadColumnPosition.MIDDLE && component.transform.position.x <= PhysicValuesReference.TRANSFORM_X_LEFT_COLUMN)
                || (component._currentColumn == RoadColumnPosition.RIGHT && component.transform.position.x <= PhysicValuesReference.TRANSFORM_X_MIDDLE_COLUMN))
            {
                return new GoForwardScooterMoveState();
            }

            return null;
        }

        public override void OnEnter(ScooterMoveComponent component)
        {
            component.transform.DORotate(new Vector3(0, 0, PhysicValuesReference.ANGLE_Z_ROTATION_LEFT), PhysicValuesReference.ANGLE_Z_ROTATION_TIME_SWIPE);
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

            component.transform.DORotate(Vector3.zero, PhysicValuesReference.ROTATION_TIME_RECOVERY);
        }

        public override void OnFixedUpdate(ScooterMoveComponent component)
        {
            component._scooterRigidbody.MovePosition(component.transform.position + (new Vector3(-1 * component._scooterParameters.DodgeSpeed, 0, 1) * Time.deltaTime * component._scooterParameters.Speed));
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
