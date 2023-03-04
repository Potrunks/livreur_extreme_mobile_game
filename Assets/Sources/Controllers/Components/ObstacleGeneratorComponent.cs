using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneratorComponent : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    private List<Transform> _obstacleSpawnPositions;
    [SerializeField]
    private List<Obstacle> _obstacleAssets;
    [SerializeField]
    private float _spawnPercentage;

    private IMapGeneratorBusiness _mapGeneratorBusiness;

    private void Awake()
    {
        _mapGeneratorBusiness = new MapGeneratorBusiness();

        _mapGeneratorBusiness.SpawnObstaclesRandomly(_obstacleAssets, _obstacleSpawnPositions, _spawnPercentage);
    }
}
