using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Entities
{
    public class MapGeneratorDto
    {
        public List<GameObject> ChunckRoadsInstantiated { get; set; }
        public Transform LastChunckRoadInstantiated { get; set; }
        public RoadLevel CurrentLevel { get; set; }
        public RoadLevel LevelBeforeTunnel { get; set; }
    }
}
