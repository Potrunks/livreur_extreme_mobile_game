using Assets.Sources.Business.Interface;
using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Messages;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class ScooterBusiness : IScooterBusiness
    {
        public void DoSwipe(Vector2 swipeInput, RoadColumnPosition currentColumn, IScooterMoveState currentState, bool isScooterGrounding)
        {
            if (swipeInput.y > 0)
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
                switch (swipeInput.x)
                {
                    case > 0:
                        if (currentColumn != RoadColumnPosition.RIGHT)
                        {
                            currentState.OnPlayerInput(ScooterAction.SWIPE_RIGHT);
                        }
                        else
                        {
                            Debug.LogWarning(string.Format(StateMessages.COLUMN_CONSTRAINT_ACTION, ScooterAction.SWIPE_RIGHT, currentColumn));
                        }
                        break;
                    case < 0:
                        if (currentColumn != RoadColumnPosition.LEFT)
                        {
                            currentState.OnPlayerInput(ScooterAction.SWIPE_LEFT);
                        }
                        else
                        {
                            Debug.LogWarning(string.Format(StateMessages.COLUMN_CONSTRAINT_ACTION, ScooterAction.SWIPE_LEFT, currentColumn));
                        }
                        break;
                    default:
                        break;
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
