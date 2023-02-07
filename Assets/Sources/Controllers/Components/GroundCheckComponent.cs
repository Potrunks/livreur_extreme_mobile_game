using Assets.Sources.Business.Tools;
using UnityEngine;

public class GroundCheckComponent : MonoBehaviour
{
    [Header("Required Components")]
    [SerializeField]
    private MoveComponent _moveComponent;

    [Header("Parameters")]
    public float _radius;
    public LayerMask _groundLayer;

    private void Update()
    {
        _moveComponent._isGrounding = this.IsGrounding();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
