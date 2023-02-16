using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Entities;
using System.Collections.Generic;
using UnityEngine;

public class RoadMapGeneratorComponent : MonoBehaviour
{
    /**
     * BUT : G�n�rer une map aleatoirement
     * Il faut un previous, current et next chunck
     * Arriv� a la moiti� du current, load le next et delete le previous
     * 
     * Un tron�on est compos� de chuncks.
     * Un chunck contient un morceau de route al�atoire issu d'un vivier de route qui ont un pourcentage de chance de pop.
     */

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
