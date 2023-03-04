using UnityEngine;

namespace Assets.Sources.Entities
{
    [CreateAssetMenu(menuName = "Road Assets/New Obstacle")]
    public class Obstacle : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public GameObject Model { get; private set; }
    }
}
