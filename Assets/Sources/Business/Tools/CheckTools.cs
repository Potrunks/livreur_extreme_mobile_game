using Assets.Sources.Entities;
using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sources.Business.Tools
{
    public static class CheckTools
    {
        /// <summary>
        /// Check if the GroundCheckComponent is grounding.
        /// </summary>
        public static bool IsGrounding(this GroundCheckComponent groundCheckComponent)
        {
            Collider[] colliderTouch = Physics.OverlapSphere(groundCheckComponent.transform.position, groundCheckComponent._radius, groundCheckComponent._groundLayer);
            if (colliderTouch.Any())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the obstacle have enough places to be instantiate and if there are already an anti ground-air obstacle instantiated.
        /// </summary>
        public static bool CanBeInstantiate(this Obstacle obstacleToCheck, IDictionary<float, Obstacle> obstaclesAlreadyInstantiate, int maxSpawnSlot, float spawnZoneXPositionSelected)
        {
            if (obstacleToCheck.BlockageType == ObstacleBlockageType.GROUND_AIR && obstaclesAlreadyInstantiate.Values.Any(obs => obs.BlockageType == ObstacleBlockageType.GROUND_AIR))
            {
                return false;
            }

            IEnumerable<float> spawnZonesNeighborXPosition = GetSpawnZoneObstacleNeighborsXPosition(spawnZoneXPositionSelected, obstaclesAlreadyInstantiate.Keys);
            foreach (float neighborXPosition in spawnZonesNeighborXPosition)
            {
                BoxCollider transformToCheck = obstacleToCheck.Model.GetComponent<BoxCollider>();
                BoxCollider transformNeighbor = obstaclesAlreadyInstantiate[neighborXPosition].Model.GetComponent<BoxCollider>();

                float transformToCheckOccupedSpace = transformToCheck.size.z / 2;
                float transformNeighborOccupedSpace = transformNeighbor.size.z / 2;
                float availableDistance = Mathf.Abs(spawnZoneXPositionSelected - neighborXPosition);

                if ((transformNeighborOccupedSpace + transformToCheckOccupedSpace) >= availableDistance)
                {
                    return false;
                }
            }

            return true;
        }

        private static IEnumerable<float> GetSpawnZoneObstacleNeighborsXPosition(float spawnZoneXPositionSelected, IEnumerable<float> spawnZonesXPositionAlreadyUsed)
        {
            if (spawnZoneXPositionSelected == RoadMapGeneratorComponent._instance._leftColumnXPosition || spawnZoneXPositionSelected == RoadMapGeneratorComponent._instance._rightColumnXPosition)
            {
                return spawnZonesXPositionAlreadyUsed.Where(pos => pos == RoadMapGeneratorComponent._instance._middleColumnXPosition);
            }

            if (spawnZoneXPositionSelected == RoadMapGeneratorComponent._instance._middleColumnXPosition)
            {
                return spawnZonesXPositionAlreadyUsed.Where(pos => pos == RoadMapGeneratorComponent._instance._leftColumnXPosition || pos == RoadMapGeneratorComponent._instance._rightColumnXPosition);
            }

            return new List<float>();
        }
    }
}
