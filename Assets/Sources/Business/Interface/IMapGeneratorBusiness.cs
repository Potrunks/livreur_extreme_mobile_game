using Assets.Sources.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface IMapGeneratorBusiness
    {
        Transform SpawnChuncksRoadRandomly(List<ChunckRoad> chuncksRoadStock, Transform lastChunckRoadTransform, Transform parent, int chuncksNumber);
    }
}
