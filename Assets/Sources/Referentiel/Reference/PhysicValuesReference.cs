using System.Numerics;

namespace Assets.Sources.Referentiel.Reference
{
    public static class PhysicValuesReference
    {
        public static float VELOCITY_Y_LOW_THRESHOLD = -0.1f;

        public static float TRANSFORM_X_LEFT_COLUMN = -8.75f;
        public static float TRANSFORM_X_RIGHT_COLUMN = -3.75f;
        public static float TRANSFORM_X_MIDDLE_COLUMN = -6.25f;

        public static int ANGLE_Z_ROTATION_LEFT = 10;
        public static int ANGLE_Z_ROTATION_RIGHT = -10;
        public static int ANGLE_X_ROTATION_JUMP = -20;
        public static int ANGLE_X_ROTATION_FALL = 20;

        public static float ANGLE_Z_ROTATION_TIME_SWIPE = 0.25f;
        public static float ANGLE_X_ROTATION_TIME_JUMP = 0.25f;
        public static float ANGLE_X_ROTATION_TIME_FALL = 0.25f;
        public static float ROTATION_TIME_RECOVERY = 0.1f;
    }
}
