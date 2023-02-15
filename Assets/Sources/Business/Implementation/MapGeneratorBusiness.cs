using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class MapGeneratorBusiness : IMapGeneratorBusiness
    {
        public Transform SpawnChuncksRoadRandomly(List<ChunckRoad> chuncksRoad, Transform lastChunckRoadPosition, Transform parent, int chuncksNumber)
        {
            for (int i = 0; i < chuncksNumber; i++)
            {
                GameObject newChunckRoad = GameObject.Instantiate
                (
                    chuncksRoad[0].Model,
                    new Vector3
                        (
                            lastChunckRoadPosition.position.x,
                            lastChunckRoadPosition.position.y,
                            lastChunckRoadPosition.position.z + chuncksRoad[0].Length
                        ),
                    lastChunckRoadPosition.rotation,
                    parent
                );
                lastChunckRoadPosition = newChunckRoad.transform;
            }

            return lastChunckRoadPosition;
        }
    }
}
