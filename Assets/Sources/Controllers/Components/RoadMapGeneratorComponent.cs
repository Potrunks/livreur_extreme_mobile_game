using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

public class RoadMapGeneratorComponent : MonoBehaviour
{
    [Header("Parameters")]
    [Header("Starter Chunck Road")]
    [SerializeField]
    private GameObject _firstChunckRoadPrefab;
    [SerializeField]
    private RoadLevel _firstLevel;
    [Header("Generator Values")]
    [SerializeField]
    private int _chuncksNumber;
    [SerializeField]
    private List<ChunckRoad> _chuncksRoad;
    [Header("Column Position")]
    public float _leftColumnXPosition = -8.75f;
    public float _rightColumnXPosition = -3.75f;
    public float _middleColumnXPosition = -6.25f;

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
            LastChunckRoadInstantiated = _firstChunckRoadPrefab.transform,
            LevelBeforeTunnel = _firstLevel,
            ChunckRoadsInstantiated = new List<GameObject> { _firstChunckRoadPrefab }
        };
    }

    private void Start()
    {
        _currentMapGeneratorDto = _mapGeneratorBusiness.InstantiateRandomChunckRoads(_chuncksRoad, transform, _chuncksNumber, _currentMapGeneratorDto);
    }

    /// <summary>
    /// Spawn multiple chunck road randomly (executed from a SpawnerCheckpointComponent).
    /// </summary>
    public void SpawnMultipleChunckRoadRandomly(SpawnerCheckpointComponent spawner)
    {
        _currentMapGeneratorDto = _mapGeneratorBusiness.InstantiateRandomChunckRoads(_chuncksRoad, transform, _chuncksNumber, _currentMapGeneratorDto);
        spawner.gameObject.SetActive(false);
    }
}
