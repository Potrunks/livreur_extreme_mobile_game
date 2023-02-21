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
    public static RoadMapGeneratorComponent _instance;
    private IMapGeneratorBusiness _mapGeneratorBusiness;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(_instance);
            return;
        }

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
        _currentMapGeneratorDto = _mapGeneratorBusiness.SpawnMultipleChunckRoadRandomly(_chuncksRoad, transform, _chuncksNumber, _currentMapGeneratorDto);
    }

    public void SpawnMultipleChunckRoadRandomly(GameObject spawner)
    {
        _currentMapGeneratorDto = _mapGeneratorBusiness.SpawnMultipleChunckRoadRandomly(_chuncksRoad, transform, _chuncksNumber, _currentMapGeneratorDto);
        spawner.SetActive(false);
    }
}
