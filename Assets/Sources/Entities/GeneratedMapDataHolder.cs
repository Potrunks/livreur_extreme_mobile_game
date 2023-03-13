using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Entities
{
    public class GeneratedMapDataHolder
    {
        public GeneratedMapDataHolder(GameObject firstChunckRoadInstantiated, RoadLevel firstChunckRoadLevel)
        {
            LastChunckRoadInstantiated = firstChunckRoadInstantiated;
            CurrentLevel = firstChunckRoadLevel;
            LevelBeforeTunnel = firstChunckRoadLevel;
            DestroyGameObjectsQueue = new List<GameObject>();
        }

        public GameObject LastChunckRoadInstantiated { get; set; }
        public RoadLevel CurrentLevel { get; set; }
        public RoadLevel LevelBeforeTunnel { get; set; }
        public List<GameObject> DestroyGameObjectsQueue { get; set; }
    }
}
