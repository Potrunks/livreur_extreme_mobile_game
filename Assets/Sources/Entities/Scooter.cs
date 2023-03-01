using UnityEngine;

[CreateAssetMenu(menuName = "Scooter/New")]
public class Scooter : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    public int MoveSpeed { get; set; }

    [field: SerializeField]
    public int DodgeSpeed { get; set; }

    [field: SerializeField]
    public int JumpSpeed { get; set; }

    [field: SerializeField]
    public int FallSpeed { get; set; }
}
