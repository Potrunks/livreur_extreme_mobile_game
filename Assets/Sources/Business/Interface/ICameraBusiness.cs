using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface ICameraBusiness
    {
        /// <summary>
        /// Allow the camera to follow the target depending of different axis mode.
        /// </summary>
        /// <param name="cameraPosition"></param>
        /// <param name="targetPosition"></param>
        /// <param name="offset">The distance between target and camera set by developper in inspector.</param>
        /// <param name="followModes">The different axis of following.</param>
        /// <returns>The new position of the camera.</returns>
        Vector3 FollowTarget(Vector3 cameraPosition, Vector3 targetPosition, Vector3 offset, List<CameraFollowMode> followModes);

        /// <summary>
        /// Calculate the offset distance between camera and target.
        /// </summary>
        /// <param name="cameraPosition"></param>
        /// <param name="targetPosition"></param>
        /// <returns>The offset Vector3 value.</returns>
        Vector3 CalculateOffsetDistance(Vector3 cameraPosition, Vector3 targetPosition);
    }
}
