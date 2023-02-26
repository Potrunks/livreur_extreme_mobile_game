using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface IScooterBusiness
    {
        void DoSwipe(float swipeXDirection, RoadColumnPosition currentColumn, IScooterMoveState currentState);
    }
}
