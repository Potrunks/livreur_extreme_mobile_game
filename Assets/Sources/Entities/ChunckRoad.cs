using Assets.Sources.Referentiel.Enum;
using UnityEngine;

namespace Assets.Sources.Entities
{
    [CreateAssetMenu(menuName = "Road Assets/New Chunck Road")]
    public class ChunckRoad : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public GameObject Model { get; private set; }

        [field: SerializeField]
        public int SpawnPercentage { get; private set; }

        [field: SerializeField]
        public RoadLevel RoadLevel { get; private set; }
    }
}
