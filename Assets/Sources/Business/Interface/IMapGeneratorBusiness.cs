using Assets.Sources.Entities;
using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface IMapGeneratorBusiness
    {
        MapGeneratorDto SpawnMultipleChunckRoadRandomly(List<ChunckRoad> chuncksRoadStock, Transform lastChunckRoadTransform, Transform parent, int chuncksNumber, RoadLevel currentLevel, RoadLevel beforeTunnel);
        MapGeneratorDto SpawnRandomChunckRoad(List<ChunckRoad> chuncksRoadStock, Transform lastChunckRoadTransform, Transform parent, RoadLevel currentLevel, RoadLevel beforeTunnel);
    }
}
