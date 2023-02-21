using Assets.Sources.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface IMapGeneratorBusiness
    {
        MapGeneratorDto SpawnMultipleChunckRoadRandomly(List<ChunckRoad> chuncksRoadStock, Transform parent, int chuncksNumber, MapGeneratorDto currentMapGeneratorDto);

        MapGeneratorDto SpawnRandomChunckRoad(List<ChunckRoad> chuncksRoadStock, Transform parent, MapGeneratorDto currentMapGeneratorDto);
    }
}
