using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using Assets.Sources.Referentiel.Reference;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class MapGeneratorBusiness : IMapGeneratorBusiness
    {
        public Transform SpawnChuncksRoadRandomly(List<ChunckRoad> chuncksRoadStock, Transform lastChunckRoadTransform, Transform parent, int chuncksNumber)
        {
            for (int i = 0; i < chuncksNumber; i++)
            {
                ChunckRoad chunckRoadToSpawn = GetRandomChunckRoadModel(chuncksRoadStock);

                GameObject newChunckRoad = GameObject.Instantiate
                (
                    chunckRoadToSpawn.Model,
                    lastChunckRoadTransform.position,
                    chunckRoadToSpawn.Model.transform.rotation,
                    parent
                );

                Vector3 offset = CalculateOffsetBetweenTwoChuncksRoad(lastChunckRoadTransform, newChunckRoad.transform);
                newChunckRoad.transform.position = new Vector3
                    (
                        newChunckRoad.transform.position.x + offset.x,
                        newChunckRoad.transform.position.y + offset.y,
                        newChunckRoad.transform.position.z + offset.z
                    );

                newChunckRoad.name = chunckRoadToSpawn.Name;
                lastChunckRoadTransform = newChunckRoad.transform;
            }

            return lastChunckRoadTransform;
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

        private ChunckRoad GetRandomChunckRoadModel(List<ChunckRoad> chuncksRoadStock)
        {
            int randomSpawnPercentage = Random.Range(RangeValueReference.MIN_RANGE_SPAWN_PERCENTAGE, RangeValueReference.MAX_RANGE_SPAWN_PERCENTAGE);
            List<ChunckRoad> chuncksRoadSelected = chuncksRoadStock.Where(chr => chr.SpawnPercentage >= randomSpawnPercentage).ToList();
            int randomSpawnIndex = Random.Range(RangeValueReference.MIN_RANGE_SPAWN_INDEX, chuncksRoadSelected.Count());
            return chuncksRoadSelected[randomSpawnIndex];
        }
    }
}
