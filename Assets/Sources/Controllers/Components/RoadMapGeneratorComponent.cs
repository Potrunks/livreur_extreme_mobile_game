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
    private int _numberChunckRoadBeforeEndForSpawner;
    public int _numberChunckRoadsStayAfterScooter;
    public bool _hasObstacleGenerated;
    [SerializeField]
    private List<ChunckRoad> _chuncksRoad;
    [Header("Column Position")]
    public float _leftColumnXPosition = -8.75f;
    public float _rightColumnXPosition = -3.75f;
    public float _middleColumnXPosition = -6.25f;

    public GeneratedMapDataHolder _generatedMapDataHolder;
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

        _generatedMapDataHolder = new GeneratedMapDataHolder(_firstChunckRoadPrefab, _firstLevel);
    }

    private void Start()
    {
        _mapGeneratorBusiness.InstantiateRandomChunckRoads(_chuncksRoad, transform, _chuncksNumber, _generatedMapDataHolder, _numberChunckRoadBeforeEndForSpawner);
    }

    /// <summary>
    /// Spawn multiple chunck road randomly (executed from a SpawnerCheckpointComponent).
    /// </summary>
    public void SpawnMultipleChunckRoadRandomly(EndRoadCheckpointComponent spawner)
    {
        _mapGeneratorBusiness.InstantiateRandomChunckRoads(_chuncksRoad, transform, _chuncksNumber, _generatedMapDataHolder, spawner, _numberChunckRoadBeforeEndForSpawner);
    }
}
