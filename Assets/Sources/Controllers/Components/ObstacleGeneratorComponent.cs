using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneratorComponent : MonoBehaviour
{
    [Header("Parameters")]
    [Header("Spawn Zones")]
    [SerializeField]
    private Transform _leftSpawnZone;
    [SerializeField]
    private Transform _middleSpawnZone;
    [SerializeField]
    private Transform _rightSpawnZone;
    [Header("Offset Position Values")]
    [SerializeField]
    private float _obstacleOffsetYPosition;
    [SerializeField]
    private float _obstacleOffsetZPosition;
    [Header("Generator Values")]
    [SerializeField]
    private float _spawnPercentage;
    [SerializeField]
    private List<Obstacle> _obstacleAssets;

    private List<Transform> _allSpawnTransform;

    private IMapGeneratorBusiness _mapGeneratorBusiness;

    private void Awake()
    {
        _mapGeneratorBusiness = new MapGeneratorBusiness();
    }

    private void Start()
    {
        IDictionary<RoadColumnPosition, Transform> spawnZonesByColumn = new Dictionary<RoadColumnPosition, Transform>();
        spawnZonesByColumn.Add(RoadColumnPosition.LEFT, _leftSpawnZone);
        spawnZonesByColumn.Add(RoadColumnPosition.MIDDLE, _middleSpawnZone);
        spawnZonesByColumn.Add(RoadColumnPosition.RIGHT, _rightSpawnZone);
        IDictionary<RoadColumnPosition, float> columnXPositonsByColumn = new Dictionary<RoadColumnPosition, float>();
        columnXPositonsByColumn.Add(RoadColumnPosition.LEFT, RoadMapGeneratorComponent._instance._leftColumnXPosition);
        columnXPositonsByColumn.Add(RoadColumnPosition.MIDDLE, RoadMapGeneratorComponent._instance._middleColumnXPosition);
        columnXPositonsByColumn.Add(RoadColumnPosition.RIGHT, RoadMapGeneratorComponent._instance._rightColumnXPosition);
        _allSpawnTransform = _mapGeneratorBusiness.PutSpawnObstacleZoneByRoadColumn(spawnZonesByColumn, columnXPositonsByColumn, _obstacleOffsetYPosition, _obstacleOffsetZPosition);

        _mapGeneratorBusiness.SpawnObstaclesRandomly(_obstacleAssets, _allSpawnTransform, _spawnPercentage);
    }
}
