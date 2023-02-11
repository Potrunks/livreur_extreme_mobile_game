﻿using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Messages;
using Assets.Sources.Referentiel.Reference;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Controllers.States.Scooter.Implementation
{
    public class GoForwardScooterMoveState : ScooterMoveState
    {
        public GoForwardScooterMoveState()
        {
            _possibleStateByAction = new Dictionary<ScooterAction, IScooterMoveState>
            {
                {ScooterAction.JUMP, new JumpScooterMoveState() },
                {ScooterAction.SWIPE_LEFT, new SwipeLeftScooterMoveState()},
                {ScooterAction.SWIPE_RIGHT, new SwipeRightScooterMoveState()}
            };
        }

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
            component.transform.DORotate(Vector3.zero, PhysicValuesReference.ROTATION_TIME_RECOVERY);
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
