using UnityEngine;

namespace Game.Characters.Controller
{
    public class GameStateManager : MonoBehaviour {
        private void Start()
        {
            EasyGameStateProvider.IsPaused = false;
            EasyGameStateProvider.IsPlayerAlive = true;
        }
    }
}
