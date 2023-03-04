using Assets.Sources.Entities;
using Assets.Sources.Referentiel.Enum;
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

        void SpawnObstaclesRandomly(List<Obstacle> obstacleAssets, List<Transform> obstacleSpawnPositions, float spawnPercentage);

        List<Transform> PutSpawnObstacleZoneByRoadColumn(IDictionary<RoadColumnPosition, Transform> spawnObstacleZones, IDictionary<RoadColumnPosition, float> columnXPositions, float offsetYPositon, float offsetZPosition);
    }
}
