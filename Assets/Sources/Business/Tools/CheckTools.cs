using Assets.Sources.Entities;
using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sources.Business.Tools
{
    public static class CheckTools
    {
        public static bool IsGrounding(this GroundCheckComponent groundCheckComponent)
        {
            Collider[] colliderTouch = Physics.OverlapSphere(groundCheckComponent.transform.position, groundCheckComponent._radius, groundCheckComponent._groundLayer);
            if (colliderTouch.Any())
            {
                return true;
            }
            return false;
        }

        public static bool CanBeInstantiate(this Obstacle obstacleToCheck, List<Obstacle> obstaclesAlreadyInstantiate, int maxSpawnSlot)
        {
            if (obstacleToCheck.BlockageType != ObstacleBlockageType.GROUND_AIR)
            {
                return true;
            }

            if (obstaclesAlreadyInstantiate.Count < maxSpawnSlot - 1)
            {
                return true;
            }

            if (obstaclesAlreadyInstantiate.Any(obs => obs.BlockageType != ObstacleBlockageType.GROUND_AIR))
            {
                return true;
            }

            return false;
        }
    }
}
