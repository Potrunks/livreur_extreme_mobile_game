using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Entities
{
    public class GeneratedMapDataHolder
    {
        public GeneratedMapDataHolder(GameObject firstChunckRoadInstantiated, RoadLevel firstChunckRoadLevel)
        {
            ChunckRoadsInstantiated = new List<GameObject> { firstChunckRoadInstantiated };
            LastChunckRoadInstantiated = firstChunckRoadInstantiated;
            CurrentLevel = firstChunckRoadLevel;
            LevelBeforeTunnel = firstChunckRoadLevel;
        }

        public List<GameObject> ChunckRoadsInstantiated { get; set; }
        public GameObject LastChunckRoadInstantiated { get; set; }
        public RoadLevel CurrentLevel { get; set; }
        public RoadLevel LevelBeforeTunnel { get; set; }
    }
}
