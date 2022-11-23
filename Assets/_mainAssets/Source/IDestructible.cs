using UnityEngine;

namespace Game
{
    public interface IDestructible
    {
        void Destroy(Vector3 destroyerPosition);
    }
}
