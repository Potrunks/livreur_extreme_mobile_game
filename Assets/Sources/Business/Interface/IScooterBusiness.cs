using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface IScooterBusiness
    {
        void DoSwipe(Vector2 swipeInput, RoadColumnPosition currentColumn, IScooterMoveState currentState);
    }
}
