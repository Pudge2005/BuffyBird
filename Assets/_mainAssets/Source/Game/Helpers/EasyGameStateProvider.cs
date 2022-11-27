namespace Game.Characters.Controller
{
    public static class EasyGameStateProvider
    {
        public static bool IsPaused { get; internal set; }
        public static bool IsPlayerAlive { get; internal set; }
    }
}
