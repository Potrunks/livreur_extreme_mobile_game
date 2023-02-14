using Assets.Sources.Business.Interface;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class MapGeneratorBusiness : IMapGeneratorBusiness
    {
        public ChunckRoadParametersComponent InstantiateChunckRoad(GameObject chunckRoadPrefab, ChunckRoadParametersComponent lastChunckRoadInstantiated, Transform parent)
        {
            GameObject newChunckRoad = GameObject.Instantiate
                (
                    chunckRoadPrefab,
                    new Vector3
                        (
                            lastChunckRoadInstantiated.transform.position.x,
                            lastChunckRoadInstantiated.transform.position.y,
                            lastChunckRoadInstantiated.transform.position.z + lastChunckRoadInstantiated.Length
                        ),
                    lastChunckRoadInstantiated.transform.rotation,
                    parent
                );

            return newChunckRoad.GetComponent<ChunckRoadParametersComponent>();
        }
    }
}
