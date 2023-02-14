using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface IMapGeneratorBusiness
    {
        ChunckRoadParametersComponent InstantiateChunckRoad(GameObject chunckRoadPrefab, ChunckRoadParametersComponent lastChunckRoadInstantiated, Transform parent);
    }
}
