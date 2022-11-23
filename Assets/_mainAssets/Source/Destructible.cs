using UnityEngine;

namespace Game
{
    public class Destructible : DestructibleBase
    {
        [SerializeField] private float _force = 2f;
        [SerializeField] private float _radius = 1.5f;
        [SerializeField] private float _upwards = 0.8f;

        public override void Destroy(Vector3 destroyerPosition)
        {
            Vector2 point = destroyerPosition;

            foreach (var part in Parts)
            {
                var rb = part.Unbake();
                rb.AddExplosionForce(_force, point, _radius, _upwards, ForceMode2D.Impulse);
                Destroy(part.gameObject, FadeOffset + FadeTime);
            }
        }
    }
}
