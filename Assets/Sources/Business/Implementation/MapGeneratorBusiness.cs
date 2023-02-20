using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using Assets.Sources.Referentiel.Enum;
using Assets.Sources.Referentiel.Reference;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class MapGeneratorBusiness : IMapGeneratorBusiness
    {
        public MapGeneratorDto SpawnMultipleChunckRoadRandomly(List<ChunckRoad> chuncksRoadStock, Transform lastChunckRoadTransform, Transform parent, int chuncksNumber, RoadLevel currentLevel, RoadLevel beforeTunnel)
        {
            MapGeneratorDto mapGeneratorDto = new MapGeneratorDto
            {
                CurrentLevel = currentLevel,
                LevelBeforeTunnel = beforeTunnel,
                LastChunckRoadInstantiated = lastChunckRoadTransform
            };

            for (int i = 0; i < chuncksNumber; i++)
            {
                mapGeneratorDto = SpawnRandomChunckRoad(chuncksRoadStock, mapGeneratorDto.LastChunckRoadInstantiated, parent, mapGeneratorDto.CurrentLevel, mapGeneratorDto.LevelBeforeTunnel);
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
                    return null;
            }
        }

        public MapGeneratorDto SpawnRandomChunckRoad(List<ChunckRoad> chuncksRoadStock, Transform lastChunckRoadTransform, Transform parent, RoadLevel currentLevel, RoadLevel beforeTunnel)
        {
            MapGeneratorDto mapGeneratorDto = new MapGeneratorDto
            {
                CurrentLevel = currentLevel,
                LevelBeforeTunnel = beforeTunnel,
                LastChunckRoadInstantiated = lastChunckRoadTransform
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
    }
}
