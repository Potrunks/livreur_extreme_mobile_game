using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface IScooterBusiness
    {
        /// <summary>
        /// Perform swipe move.
        /// </summary>
        void DoSwipe(Vector2 swipeInput, RoadColumnPosition currentColumn, IScooterMoveState currentState, bool isScooterGrounding);

        /// <summary>
        /// Get the new current road column position depending on the swipe direction.
        /// </summary>
        RoadColumnPosition GetNewCurrentRoadColumnPosition(RoadColumnPosition currentRoadColumnPosition, bool isSwipingRight);
    }
}
