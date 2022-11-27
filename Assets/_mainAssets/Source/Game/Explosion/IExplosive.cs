using UnityEngine;

namespace Game.Explosions
{
    public interface IExplosive
    {
        void Explode(float force, Vector2 origin, float radius);
    }
}
