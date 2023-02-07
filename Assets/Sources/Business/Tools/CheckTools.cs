using System.Linq;
using UnityEngine;

namespace Assets.Sources.Business.Tools
{
    public static class CheckTools
    {
        public static bool IsGrounding(this GroundCheckComponent groundCheckComponent)
        {
            Collider[] colliderTouch = Physics.OverlapSphere(groundCheckComponent.transform.position, groundCheckComponent._radius, groundCheckComponent._groundLayer);
            if (colliderTouch.Any())
            {
                return true;
            }
            return false;
        }
    }
}
