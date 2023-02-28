namespace Assets.Sources.Referentiel.Reference
{
    public static class PhysicValuesReference
    {
        public static float FALL_Y_DIRECTION = -1;

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
