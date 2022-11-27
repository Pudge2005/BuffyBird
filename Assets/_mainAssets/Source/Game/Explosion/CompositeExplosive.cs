using UnityEngine;

namespace Game.Explosions
{
    public class CompositeExplosive : LinkedExplosive
    {
        [SerializeField] private Renderer _facade;


        protected override void HandleExplosion(float force, Vector2 origin, float radius)
        {

            base.HandleExplosion(force, origin, radius);
        }
    }
}
