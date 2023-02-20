using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

public class RoadMapGeneratorComponent : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    private Transform _firstChunckRoadTransform;
    [SerializeField]
    private RoadLevel _firstLevel;
    [SerializeField]
    private int _chuncksNumber;
    [SerializeField]
    private List<ChunckRoad> _chuncksRoad;

    private MapGeneratorDto _currentMapGeneratorDto;

    private IMapGeneratorBusiness _mapGeneratorBusiness;

    private void Awake()
    {
        _mapGeneratorBusiness = new MapGeneratorBusiness();

        _currentMapGeneratorDto = new MapGeneratorDto
        {
            CurrentLevel = _firstLevel,
            LastChunckRoadInstantiated = _firstChunckRoadTransform,
            LevelBeforeTunnel = _firstLevel
        };
    }

    private void Start()
    {
        _currentMapGeneratorDto = _mapGeneratorBusiness.SpawnMultipleChunckRoadRandomly(_chuncksRoad, _currentMapGeneratorDto.LastChunckRoadInstantiated, transform, _chuncksNumber, _currentMapGeneratorDto.CurrentLevel, _currentMapGeneratorDto.LevelBeforeTunnel);
    }
}
