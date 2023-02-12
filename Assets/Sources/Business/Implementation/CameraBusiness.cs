using Assets.Sources.Business.Interface;
using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Implementation
{
    public class CameraBusiness : ICameraBusiness
    {
        public Vector3 FollowTarget(Vector3 follower, Vector3 target, Vector3 offset, List<CameraFollowMode> modeList)
        {
            return new Vector3
            {
                x = (modeList.Contains(CameraFollowMode.X_POSITION) ? target.x : follower.x) + offset.x,
                y = (modeList.Contains(CameraFollowMode.Y_POSITION) ? target.y : follower.y) + offset.y,
                z = (modeList.Contains(CameraFollowMode.Z_POSITION) ? target.z : follower.z) + offset.z,
            };
        }
    }
}
