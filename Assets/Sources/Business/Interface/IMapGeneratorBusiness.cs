using Assets.Sources.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface IMapGeneratorBusiness
    {
        /// <summary>
        /// Spawn randomly a multiple of chunck road.
        /// </summary>
        /// <param name="chuncksRoadStock"></param>
        /// <param name="parent">Transform who contain all new chunck road spawned.</param>
        /// <param name="chuncksNumber">Number of chunck road to instantiate.</param>
        /// <param name="currentMapGeneratorDto">Hold different value about map generator.</param>
        /// <returns>Map generator Dto with all value currently used.</returns>
        MapGeneratorDto SpawnMultipleChunckRoadRandomly(List<ChunckRoad> chuncksRoadStock, Transform parent, int chuncksNumber, MapGeneratorDto currentMapGeneratorDto);

        /// <summary>
        /// Spawn one chunck road randomly containing in a list of chunck road.
        /// </summary>
        /// <param name="chuncksRoadStock"></param>
        /// <param name="parent">Transform who contain all new chunck road spawned.</param>
        /// <param name="currentMapGeneratorDto">Hold different value about map generator.</param>
        /// <returns>Map generator Dto with all value currently used.</returns>
        MapGeneratorDto SpawnRandomChunckRoad(List<ChunckRoad> chuncksRoadStock, Transform parent, MapGeneratorDto currentMapGeneratorDto);

        /// <summary>
        /// Spawn obstacles randomly.
        /// </summary>
        void SpawnObstaclesRandomly(List<Obstacle> obstacleAssets, IDictionary<float, Transform> obstacleSpawnZones, float spawnPercentage);

        /// <summary>
        /// Place the spawn obstacle zones according to the column position of the map generator component (Need to be in Start Method).
        /// </summary>
        IDictionary<float, Transform> PutSpawnObstacleZoneByRoadColumn(Transform leftSpawnZone, Transform middleSpawnZone, Transform rightSpawnZone, float offsetYPosition, float offsetZPosition);
    }
}
