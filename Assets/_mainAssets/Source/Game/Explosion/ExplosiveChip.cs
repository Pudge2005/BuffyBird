using Game.Helpers;
using UnityEngine;

namespace Game.Explosions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ExplosiveChip : ExplosiveComponent
    {
        private Rigidbody2D _rb;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }


        protected override void HandleExplosion(float force, Vector2 origin, float radius)
        {
            _rb.simulated = true;
            _rb.AddExplosionForce(force, origin, radius, 0);
        }
    }
}
