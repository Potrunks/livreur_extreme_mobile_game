namespace Assets.Sources.Business.Tools
{
    public static class PhysicsTools
    {
        public static float To180Degrees(this float eulerAngle)
        {
            if (eulerAngle > 180)
            {
                return eulerAngle - 360;
            }
            return eulerAngle;
        }
    }
}
