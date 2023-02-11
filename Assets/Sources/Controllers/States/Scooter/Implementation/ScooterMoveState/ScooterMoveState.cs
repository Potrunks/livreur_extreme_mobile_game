using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;

namespace Assets.Sources.Controllers.States.Scooter.Implementation
{
    public abstract class ScooterMoveState : IScooterMoveState
    {
        public IScooterMoveState _nextState;
        public IDictionary<ScooterAction, IScooterMoveState> _possibleStateByAction;

        public abstract IScooterMoveState CheckStateChange(ScooterMoveComponent component);
        public abstract void OnEnter(ScooterMoveComponent component);
        public abstract void OnExit(ScooterMoveComponent component);
        public abstract void OnFixedUpdate(ScooterMoveComponent component);
        public abstract void OnPlayerInput(ScooterAction action);
        public abstract void OnUpdate(ScooterMoveComponent component);
    }
}
