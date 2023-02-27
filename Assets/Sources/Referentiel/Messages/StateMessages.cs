namespace Assets.Sources.Referentiel.Messages
{
    public static class StateMessages
    {
        public static string NOT_EXISTS_ACTION = "The action {0} not exists from the state {1}";
        public static string COLUMN_CONSTRAINT_ACTION = "The action {0} is not permitted because the current column is {1}";
        public static string JUMP_CONSTRAINT_ACTION = "The action JUMP is not permitted because the scooter isn't on the ground";
    }
}
