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

            if ((component._currentColumn == RoadColumnPosition.MIDDLE && component.transform.position.x <= PhysicValuesReference.LEFT_COLUMN_X_POSITION)
                || (component._currentColumn == RoadColumnPosition.RIGHT && component.transform.position.x <= PhysicValuesReference.MIDDLE_COLUMN_X_POSITION))
            {
                return new GoForwardScooterMoveState();
            }

            return null;
        }

        public override void OnEnter(ScooterMoveComponent component)
        {
            component.transform.DORotate(new Vector3(component.transform.eulerAngles.x.To180Degrees(), component.transform.eulerAngles.y.To180Degrees(), PhysicValuesReference.SWIPE_LEFT_Z_ROTATION), PhysicValuesReference.SWIPE_Z_ROTATION_DURATION);
        }

        public override void OnExit(ScooterMoveComponent component)
        {
            component._currentColumn = component._scooterBusiness.GetNewCurrentRoadColumnPosition(component._currentColumn, false);
            component.transform.DORotate(new Vector3(component.transform.eulerAngles.x.To180Degrees(), component.transform.eulerAngles.y.To180Degrees(), 0), PhysicValuesReference.UPRIGHT_Z_ROTATION_DURATION);
        }

        public override void OnFixedUpdate(ScooterMoveComponent component)
        {
            component._scooterRigidbody.MovePosition(component.transform.position + (new Vector3(-1 * component._scooterParameters.DodgeSpeed, 0, component._scooterParameters.Speed) * Time.deltaTime));
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
