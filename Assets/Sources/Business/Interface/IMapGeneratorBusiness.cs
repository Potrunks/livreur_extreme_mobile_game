using Assets.Sources.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface IMapGeneratorBusiness
    {
        Transform SpawnChuncksRoadRandomly(List<ChunckRoad> chuncksRoad, Transform lastChunckRoadPosition, Transform parent, int chuncksNumber);
    }
}
