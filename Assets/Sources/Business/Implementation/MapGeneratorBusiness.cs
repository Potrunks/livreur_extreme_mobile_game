using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class MapGeneratorBusiness : IMapGeneratorBusiness
    {
        public Transform SpawnChuncksRoadRandomly(List<ChunckRoad> chuncksRoadStock, Transform lastChunckRoadTransform, Transform parent, int chuncksNumber)
        {
            for (int i = 0; i < chuncksNumber; i++)
            {
                GameObject newChunckRoad = GameObject.Instantiate
                (
                    chuncksRoadStock[0].Model,
                    lastChunckRoadTransform.position,
                    lastChunckRoadTransform.rotation,
                    parent
                );

                Vector3 offset = CalculateOffsetBetweenTwoChuncksRoad(lastChunckRoadTransform, newChunckRoad.transform);

                newChunckRoad.transform.position = new Vector3
                    (
                        newChunckRoad.transform.position.x + offset.x,
                        newChunckRoad.transform.position.y + offset.y,
                        newChunckRoad.transform.position.z + offset.z
                    );
                newChunckRoad.name = string.Format("ChunckRoad{0}", i);
                lastChunckRoadTransform = newChunckRoad.transform;
            }

            return lastChunckRoadTransform;
        }

        private Vector3 CalculateOffsetBetweenTwoChuncksRoad(Transform lastChunck, Transform newChunck)
        {
            Transform backAnchorNewChunckRoad = newChunck.Find("BackAnchor").transform;
            Transform frontAnchorLastChunckRoad = lastChunck.Find("FrontAnchor").transform;

            return new Vector3
            {
                x = frontAnchorLastChunckRoad.position.x - backAnchorNewChunckRoad.position.x,
                y = frontAnchorLastChunckRoad.position.y - backAnchorNewChunckRoad.position.y,
                z = frontAnchorLastChunckRoad.position.z - backAnchorNewChunckRoad.position.z
            };
        }
    }
}
