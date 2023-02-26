using Assets.Sources.Business.Interface;
using Assets.Sources.Controllers.States.Scooter.Interface;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Messages;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class ScooterBusiness : IScooterBusiness
    {
        public void DoSwipe(Vector2 swipeInput, RoadColumnPosition currentColumn, IScooterMoveState currentState)
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
                        Debug.LogWarning(string.Format(StateMessages.CONSTRAINT_ACTION, ScooterAction.SWIPE_RIGHT, currentColumn));
                    }
                    break;
                case < 0:
                    if (currentColumn != RoadColumnPosition.LEFT)
                    {
                        currentState.OnPlayerInput(ScooterAction.SWIPE_LEFT);
                    }
                    else
                    {
                        Debug.LogWarning(string.Format(StateMessages.CONSTRAINT_ACTION, ScooterAction.SWIPE_LEFT, currentColumn));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
