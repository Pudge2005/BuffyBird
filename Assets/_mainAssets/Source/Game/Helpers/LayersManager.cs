using UnityEngine;

namespace Game.Helpers
{
    internal class LayersManager : MonoBehaviour
    {
        [SerializeField] private LayerMask _destructibles;


        private void Awake()
        {
            FastAccess.Interactables = _destructibles;
        }
    }
}
