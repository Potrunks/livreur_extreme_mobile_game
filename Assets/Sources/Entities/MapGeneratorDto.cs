using Assets.Sources.Referentiel.Enum;
using UnityEngine;

namespace Assets.Sources.Entities
{
    public class MapGeneratorDto
    {
        public Transform LastChunckRoadInstantiated { get; set; }
        public RoadLevel CurrentLevel { get; set; }
        public RoadLevel LevelBeforeTunnel { get; set; }
    }
}
