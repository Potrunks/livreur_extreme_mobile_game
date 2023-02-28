using System.Numerics;

namespace Assets.Sources.Referentiel.Reference
{
    public static class PhysicValuesReference
    {
        public static float LEFT_COLUMN_X_POSITION = -8.75f;
        public static float RIGHT_COLUMN_X_POSITION = -3.75f;
        public static float MIDDLE_COLUMN_X_POSITION = -6.25f;
        public static float JUMP_LIMIT_Y_POSITION = 7;

        public static int SWIPE_LEFT_Z_ROTATION = 10;
        public static int SWIPE_RIGHT_Z_ROTATION = -10;
        public static int JUMP_X_ROTATION = -20;
        public static float SWIPE_Z_ROTATION_DURATION = 0.25f;
        public static float JUMP_X_ROTATION_DURATION = 0.1f;
        public static float UPRIGHT_Z_ROTATION_DURATION = 0.1f;

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
