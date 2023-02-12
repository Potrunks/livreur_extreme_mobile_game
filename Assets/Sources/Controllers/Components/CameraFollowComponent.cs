using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowComponent : MonoBehaviour
{
    [Header("Target")]
    [SerializeField]
    private Transform _target;

    [Header("Parameters")]
    [SerializeField]
    private Vector3 _offset;
    [SerializeField]
    private List<CameraFollowMode> _modeList;

    private ICameraBusiness _cameraBusiness;

    private void Awake()
    {
        _cameraBusiness = new CameraBusiness();
    }

    private void FixedUpdate()
    {
        transform.position = _cameraBusiness.FollowTarget(transform.position, _target.position, _offset, _modeList);
    }
}