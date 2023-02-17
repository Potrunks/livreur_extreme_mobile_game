using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using System.Collections.Generic;
using UnityEngine;

public class RoadMapGeneratorComponent : MonoBehaviour
{
    [Header("Instantiate Parameters")]
    [SerializeField]
    private Transform _lastChunckRoadTransform;
    [SerializeField]
    private int _chuncksNumber;
    [SerializeField]
    private List<ChunckRoad> _chuncksRoad;

    private IMapGeneratorBusiness _mapGeneratorBusiness;

    private void Awake()
    {
        _mapGeneratorBusiness = new MapGeneratorBusiness();
    }

    private void Start()
    {
        _lastChunckRoadTransform = _mapGeneratorBusiness.SpawnChuncksRoadRandomly(_chuncksRoad, _lastChunckRoadTransform, transform, _chuncksNumber);
    }
}
