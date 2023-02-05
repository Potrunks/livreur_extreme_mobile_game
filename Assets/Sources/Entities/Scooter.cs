using UnityEngine;

[CreateAssetMenu(menuName = "Scooter/New")]
public class Scooter : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    public int Speed { get; set; }
}
