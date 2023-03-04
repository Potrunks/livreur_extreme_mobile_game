using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Messages;
using Assets.Sources.Referentiel.Reference;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class MapGeneratorBusiness : IMapGeneratorBusiness
    {
        public MapGeneratorDto SpawnMultipleChunckRoadRandomly(List<ChunckRoad> chuncksRoadStock, Transform parent, int chuncksNumber, MapGeneratorDto currentMapGeneratorDto)
        {
            MapGeneratorDto mapGeneratorDto = new MapGeneratorDto
            {
                CurrentLevel = currentMapGeneratorDto.CurrentLevel,
                LevelBeforeTunnel = currentMapGeneratorDto.LevelBeforeTunnel,
                LastChunckRoadInstantiated = currentMapGeneratorDto.LastChunckRoadInstantiated
            };

            for (int i = 0; i < chuncksNumber; i++)
            {
                mapGeneratorDto = SpawnRandomChunckRoad(chuncksRoadStock, parent, mapGeneratorDto);
                ActivateSpawnCheckpoint(chuncksNumber, i, mapGeneratorDto.LastChunckRoadInstantiated);
            }

            return mapGeneratorDto;
        }

        private Vector3 CalculateOffsetBetweenTwoChuncksRoad(Transform lastChunck, Transform newChunck)
        {
            Transform backAnchorNewChunckRoad = newChunck.Find(GameObjectNameReference.CHUNCK_ROAD_BACK_ANCHOR).transform;
            Transform frontAnchorLastChunckRoad = lastChunck.Find(GameObjectNameReference.CHUNCK_ROAD_FRONT_ANCHOR).transform;

            return new Vector3
            {
                x = frontAnchorLastChunckRoad.position.x - backAnchorNewChunckRoad.position.x,
                y = frontAnchorLastChunckRoad.position.y - backAnchorNewChunckRoad.position.y,
                z = frontAnchorLastChunckRoad.position.z - backAnchorNewChunckRoad.position.z
            };
        }

        private ChunckRoad GetRandomChunckRoadModel(List<ChunckRoad> chuncksRoadStock, RoadLevel currentLevel, RoadLevel beforeTunnel)
        {
            List<RoadLevel> availableRoadLevels = GetAvailableRoadLevel(currentLevel, beforeTunnel);
            int randomSpawnPercentage = Random.Range(RangeValueReference.MIN_RANGE_SPAWN_PERCENTAGE, RangeValueReference.MAX_RANGE_SPAWN_PERCENTAGE);
            List<ChunckRoad> chuncksRoadSelected = chuncksRoadStock.Where(chr => chr.SpawnPercentage >= randomSpawnPercentage && availableRoadLevels.Contains(chr.RoadLevel)).ToList();
            int randomSpawnIndex = Random.Range(RangeValueReference.MIN_RANGE_SPAWN_INDEX, chuncksRoadSelected.Count());
            return chuncksRoadSelected[randomSpawnIndex];
        }

        private List<RoadLevel> GetAvailableRoadLevel(RoadLevel currentLevel, RoadLevel beforeTunnel)
        {
            switch (currentLevel)
            {
                case RoadLevel.GROUND:
                    return new List<RoadLevel> { RoadLevel.GROUND, RoadLevel.GO_HEIGHT, RoadLevel.GO_TUNNEL };
                case RoadLevel.HEIGHT:
                    return new List<RoadLevel> { RoadLevel.HEIGHT, RoadLevel.GO_GROUND, RoadLevel.GO_TUNNEL };
                case RoadLevel.GO_HEIGHT:
                    return new List<RoadLevel> { RoadLevel.HEIGHT };
                case RoadLevel.GO_TUNNEL:
                    return new List<RoadLevel> { RoadLevel.TUNNEL };
                case RoadLevel.OUT_TUNNEL:
                    return new List<RoadLevel> { beforeTunnel };
                case RoadLevel.TUNNEL:
                    return new List<RoadLevel> { RoadLevel.TUNNEL, RoadLevel.OUT_TUNNEL };
                case RoadLevel.GO_GROUND:
                    return new List<RoadLevel> { RoadLevel.GROUND };
                default:
                    Debug.LogError(string.Format(ErrorMessages.ROAD_LEVEL_NOT_FOUND, currentLevel));
                    return null;
            }
        }

        public MapGeneratorDto SpawnRandomChunckRoad(List<ChunckRoad> chuncksRoadStock, Transform parent, MapGeneratorDto currentMapGeneratorDto)
        {
            MapGeneratorDto mapGeneratorDto = new MapGeneratorDto
            {
                CurrentLevel = currentMapGeneratorDto.CurrentLevel,
                LevelBeforeTunnel = currentMapGeneratorDto.LevelBeforeTunnel,
                LastChunckRoadInstantiated = currentMapGeneratorDto.LastChunckRoadInstantiated
            };

            ChunckRoad chunckRoadToSpawn = GetRandomChunckRoadModel(chuncksRoadStock, mapGeneratorDto.CurrentLevel, mapGeneratorDto.LevelBeforeTunnel);

            GameObject newChunckRoad = GameObject.Instantiate
            (
                chunckRoadToSpawn.Model,
                mapGeneratorDto.LastChunckRoadInstantiated.position,
                chunckRoadToSpawn.Model.transform.rotation,
                parent
            );

            Vector3 offset = CalculateOffsetBetweenTwoChuncksRoad(mapGeneratorDto.LastChunckRoadInstantiated, newChunckRoad.transform);
            newChunckRoad.transform.position = new Vector3
                (
                    newChunckRoad.transform.position.x + offset.x,
                    newChunckRoad.transform.position.y + offset.y,
                    newChunckRoad.transform.position.z + offset.z
                );

            newChunckRoad.name = chunckRoadToSpawn.Name;
            if (chunckRoadToSpawn.RoadLevel == RoadLevel.GO_TUNNEL)
            {
                mapGeneratorDto.LevelBeforeTunnel = mapGeneratorDto.CurrentLevel;
            }
            mapGeneratorDto.CurrentLevel = chunckRoadToSpawn.RoadLevel;
            mapGeneratorDto.LastChunckRoadInstantiated = newChunckRoad.transform;

            return mapGeneratorDto;
        }

        private void ActivateSpawnCheckpoint(int maxChunckRoadSpawning, int chunckRoadSpawningIndex, Transform chunckRoadSpawningTransform)
        {
            if (chunckRoadSpawningIndex == maxChunckRoadSpawning - RangeValueReference.CHUNCK_ROAD_BEFORE_END_INDEX_SPAWNER)
            {
                GameObject spawnCheckpoint = chunckRoadSpawningTransform.Find(GameObjectNameReference.CHUNCK_ROAD_SPAWN_CHECKPOINT).gameObject;
                spawnCheckpoint.SetActive(true);
            }
        }

        public void SpawnObstaclesRandomly(List<Obstacle> obstacleAssets, List<Transform> obstacleSpawnPositions, float spawnPercentage)
        {
            int randomPercentage = Random.Range(RangeValueReference.MIN_RANGE_SPAWN_PERCENTAGE, RangeValueReference.MAX_RANGE_SPAWN_PERCENTAGE);

            if (randomPercentage < spawnPercentage)
            {
                int numberOfObstacleToSpawn = Random.Range(RangeValueReference.MIN_NUMBER_OBJECT_SPAWN, obstacleSpawnPositions.Count + 1);
                List<Transform> selectedSpawns = new List<Transform>();
                List<Transform> allAvailableSpawns = obstacleSpawnPositions;

                for (int i = 0; i < numberOfObstacleToSpawn; i++)
                {
                    int randomIndex = Random.Range(RangeValueReference.MIN_RANGE_SPAWN_INDEX, allAvailableSpawns.Count);
                    Transform selectedSpawn = allAvailableSpawns[randomIndex];
                    allAvailableSpawns.Remove(selectedSpawn);
                    selectedSpawns.Add(selectedSpawn);
                }

                foreach (Transform selectedSpawn in selectedSpawns)
                {
                    int randomIndex = Random.Range(RangeValueReference.MIN_RANGE_SPAWN_INDEX, obstacleAssets.Count);
                    Obstacle obstacle = obstacleAssets[randomIndex];
                    GameObject.Instantiate
                        (
                            obstacle.Model,
                            selectedSpawn.position,
                            obstacle.Model.transform.rotation,
                            selectedSpawn
                        );
                }
            }
        }
    }
}
