using Assets.Sources.Referentiel.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Business.Interface
{
    public interface ICameraBusiness
    {
        Vector3 FollowTarget(Vector3 follower, Vector3 target, Vector3 offset, List<CameraFollowMode> modeList);
    }
}
