using UnityEngine;

namespace Game.Explosions
{
    public abstract class ExplosiveComponent : MonoBehaviour, IExplosive
    {
        public void Explode(float force, Vector2 origin, float radius)
        {
            HandleExplosion(force, origin, radius);
        }

        protected abstract void HandleExplosion(float force, Vector2 origin, float radius);
    }
}
