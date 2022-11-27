using UnityEngine;

namespace Game.Explosions
{
    public class LinkedExplosive : ExplosiveComponent
    {
        [SerializeField] private ExplosiveComponent[] _linkedExplosives;


        protected override void HandleExplosion(float force, Vector2 origin, float radius)
        {
            foreach (var ld in _linkedExplosives)
            {
                ld.Explode(force, origin, radius);
            }
        }
    }
}
