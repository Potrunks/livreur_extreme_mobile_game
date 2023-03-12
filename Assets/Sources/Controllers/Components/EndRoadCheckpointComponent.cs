using Assets.Sources.Business.Implementation;
using Assets.Sources.Business.Interface;
using Assets.Sources.Referentiel.Reference;
using UnityEngine;

public class EndRoadCheckpointComponent : MonoBehaviour
{
    [HideInInspector]
    public bool _isChunckRoadSpawner = false;
    [HideInInspector]
    public bool _hasChunckRoadGone = false;

    private IMapGeneratorBusiness _mapGeneratorBusiness = new MapGeneratorBusiness();

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject.tag == GameObjectNameReference.GAMEOBJECT_TAG_PLAYER)
        {
            if (_isChunckRoadSpawner)
            {
                RoadMapGeneratorComponent._instance.SpawnMultipleChunckRoadRandomly(this);
            }

            if (!_hasChunckRoadGone)
            {
                _mapGeneratorBusiness.AddChunckRoadDestroyQueue(this, RoadMapGeneratorComponent._instance._generatedMapDataHolder.DestroyGameObjectsQueue, RoadMapGeneratorComponent._instance._numberChunckRoadsStayAfterScooter);
            }
        }
    }
}
