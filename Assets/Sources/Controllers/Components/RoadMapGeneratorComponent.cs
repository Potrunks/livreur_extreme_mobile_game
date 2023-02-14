using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
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
    private GameObject _chunckRoadPrefab;
    [SerializeField]
    private ChunckRoadParametersComponent _lastChunckRoadInstantiated;
    [SerializeField]
    private int _numberOfInstantiate;

    private IMapGeneratorBusiness _mapGeneratorBusiness;

    private void Awake()
    {
        _mapGeneratorBusiness = new MapGeneratorBusiness();
    }

    private void Start()
    {
        for (int i = 0; i < _numberOfInstantiate; i++)
        {
            _lastChunckRoadInstantiated = _mapGeneratorBusiness.InstantiateChunckRoad(_chunckRoadPrefab, _lastChunckRoadInstantiated, transform);
        }
    }
}
