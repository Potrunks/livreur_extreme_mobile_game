using Assets.Sources.Business.Interface;
using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class CameraBusiness : ICameraBusiness
    {
        public Vector3 CalculateOffsetDistance(Vector3 cameraPosition, Vector3 targetPosition)
        {
            return new Vector3
            {
                x = cameraPosition.x - targetPosition.x,
                y = cameraPosition.y - targetPosition.y,
                z = cameraPosition.z - targetPosition.z
            };
        }

        public Vector3 FollowTarget(Vector3 cameraPosition, Vector3 targetPosition, Vector3 offset, List<CameraFollowMode> followModes)
        {
            return new Vector3
            {
                x = followModes.Contains(CameraFollowMode.X_POSITION) ? targetPosition.x + offset.x : cameraPosition.x,
                y = followModes.Contains(CameraFollowMode.Y_POSITION) ? targetPosition.y + offset.y : cameraPosition.y,
                z = followModes.Contains(CameraFollowMode.Z_POSITION) ? targetPosition.z + offset.z : cameraPosition.z,
            };
        }
    }
}
