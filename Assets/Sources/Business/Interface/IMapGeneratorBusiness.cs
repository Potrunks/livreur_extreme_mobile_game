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
        /// <param name="generatedMapDataHolder">Hold different value about map generator.</param>
        /// <returns>Map generator Dto with all value currently used.</returns>
        void InstantiateRandomChunckRoads(List<ChunckRoad> chuncksRoadStock, Transform parent, int chuncksNumber, GeneratedMapDataHolder generatedMapDataHolder, int numberChunckRoadBeforeEndForSpawner);

        void InstantiateRandomChunckRoads(List<ChunckRoad> chuncksRoadStock, Transform parent, int chuncksNumber, GeneratedMapDataHolder generatedMapDataHolder, EndRoadCheckpointComponent spawner, int numberChunckRoadBeforeEndForSpawner);

        /// <summary>
        /// Spawn obstacles randomly.
        /// </summary>
        void InstantiateRandomObstacles(List<Obstacle> obstacleAssets, IDictionary<float, Transform> obstacleSpawnZones, float spawnPercentage);

        /// <summary>
        /// Place the spawn obstacle zones according to the column position of the map generator component (Need to be in Start Method).
        /// </summary>
        IDictionary<float, Transform> PositionSpawnObstacleZoneByRoadColumn(Transform leftSpawnZone, Transform middleSpawnZone, Transform rightSpawnZone, float offsetYPosition, float offsetZPosition);

        /// <summary>
        /// Add the chunck road gone after the passage of the scooter. If the queue is full, the first chunck gone added in the list will be destroy.
        /// </summary>
        void AddChunckRoadDestroyQueue(EndRoadCheckpointComponent endRoadCheckpoint, List<GameObject> destroyChunckRoadQueue, int numberChunckRoadsStayAfterScooter);
    }
}
