using Assets.Sources.Referentiel.Reference;
using UnityEngine;

public class SpawnerCheckpointComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject.tag == GameObjectNameReference.GAMEOBJECT_TAG_PLAYER)
        {
            RoadMapGeneratorComponent._instance.SpawnMultipleChunckRoadRandomly(gameObject);
        }
    }
}
