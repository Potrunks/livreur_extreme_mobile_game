using Assets.Sources.Business.Interface;
using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Messages;
using Assets.Sources.Referentiel.Reference;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class ScooterBusiness : IScooterBusiness
    {
        public void DoSwipe(Vector2 swipeInput, RoadColumnPosition currentColumn, IScooterMoveState currentState, bool isScooterGrounding)
        {
            if (swipeInput.y > RangeValueReference.Y_DELTA_SWIPE_THRESHOLD)
            {
                if (isScooterGrounding)
                {
                    currentState.OnPlayerInput(ScooterAction.JUMP);
                }
                else
                {
                    Debug.LogWarning(StateMessages.JUMP_CONSTRAINT_ACTION);
                }
            }
            else
            {
                if (swipeInput.x > RangeValueReference.X_DELTA_SWIPE_RIGHT_THRESHOLD)
                {
                    if (currentColumn != RoadColumnPosition.RIGHT)
                    {
                        currentState.OnPlayerInput(ScooterAction.SWIPE_RIGHT);
                    }
                    else
                    {
                        Debug.LogWarning(string.Format(StateMessages.COLUMN_CONSTRAINT_ACTION, ScooterAction.SWIPE_RIGHT, currentColumn));
                    }
                }
                else if (swipeInput.x < RangeValueReference.X_DELTA_SWIPE_LEFT_THRESHOLD)
                {
                    if (currentColumn != RoadColumnPosition.LEFT)
                    {
                        currentState.OnPlayerInput(ScooterAction.SWIPE_LEFT);
                    }
                    else
                    {
                        Debug.LogWarning(string.Format(StateMessages.COLUMN_CONSTRAINT_ACTION, ScooterAction.SWIPE_LEFT, currentColumn));
                    }
                }
            }
        }

        public RoadColumnPosition GetNewCurrentRoadColumnPosition(RoadColumnPosition currentRoadColumnPosition, bool isSwipingRight)
        {
            if (isSwipingRight)
            {
                if (currentRoadColumnPosition == RoadColumnPosition.LEFT)
                {
                    return RoadColumnPosition.MIDDLE;
                }
                else if (currentRoadColumnPosition == RoadColumnPosition.MIDDLE)
                {
                    return RoadColumnPosition.RIGHT;
                }
            }
            else
            {
                if (currentRoadColumnPosition == RoadColumnPosition.MIDDLE)
                {
                    return RoadColumnPosition.LEFT;
                }
                else if (currentRoadColumnPosition == RoadColumnPosition.RIGHT)
                {
                    return RoadColumnPosition.MIDDLE;
                }
            }

            return currentRoadColumnPosition;
        }
    }
}
