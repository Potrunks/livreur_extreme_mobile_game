using UnityEngine;

namespace Assets.Sources.Entities
{
    [CreateAssetMenu(menuName = "ChunckRoad/New")]
    public class ChunckRoad : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public GameObject Model { get; private set; }

        [field: SerializeField]
        public int SpawnPercentage { get; private set; }
    }
}
