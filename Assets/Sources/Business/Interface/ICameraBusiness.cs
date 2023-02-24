using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface ICameraBusiness
    {
        Vector3 FollowTarget(Vector3 cameraPosition, Vector3 targetPosition, Vector3 offset, List<CameraFollowMode> followModes);

        Vector3 CalculateOffsetDistance(Vector3 cameraPosition, Vector3 targetPosition);
    }
}
