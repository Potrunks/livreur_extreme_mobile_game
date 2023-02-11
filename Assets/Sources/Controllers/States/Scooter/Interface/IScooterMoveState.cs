using Assets.Sources.Referentiel.Enum;

namespace Assets.Sources.Controllers.States.Scooter.Interface
{
    public interface IScooterMoveState
    {
        void OnEnter(ScooterMoveComponent component);
        void OnExit(ScooterMoveComponent component);
        IScooterMoveState CheckStateChange(ScooterMoveComponent component);
        void OnPlayerInput(ScooterAction action);
        void OnUpdate(ScooterMoveComponent component);
        void OnFixedUpdate(ScooterMoveComponent component);
    }
}
