using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
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

    private IDictionary<float, Transform> _spawnZonesByXPosition;

    private IMapGeneratorBusiness _mapGeneratorBusiness;

    private void Awake()
    {
        _mapGeneratorBusiness = new MapGeneratorBusiness();
    }

    private void Start()
    {
        _spawnZonesByXPosition = _mapGeneratorBusiness.PutSpawnObstacleZoneByRoadColumn(_leftSpawnZone, _middleSpawnZone, _rightSpawnZone, _obstacleOffsetYPosition, _obstacleOffsetZPosition);
        _mapGeneratorBusiness.SpawnObstaclesRandomly(_obstacleAssets, _spawnZonesByXPosition, _spawnPercentage);
    }
}
