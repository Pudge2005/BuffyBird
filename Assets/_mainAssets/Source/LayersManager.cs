using UnityEngine;

namespace Game
{
    internal class LayersManager : MonoBehaviour
    {
        [SerializeField] private LayerMask _destructibles;


        private void Awake()
        {
            FastAccess.Destructibles = _destructibles;
        }
    }
}
