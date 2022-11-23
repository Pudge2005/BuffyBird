using UnityEngine;

namespace Game
{
    public static class Rigidbody2DExtentions
    {
        public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition,
                                             float explosionRadius, float upwardsModifier, ForceMode2D mode)
        {
            var explosionDir = rb.position - explosionPosition;
            var explosionDistance = explosionDir.magnitude;

            if (upwardsModifier == 0)
            {
                explosionDir /= explosionDistance;
            }
            else
            {
                explosionDir.y += upwardsModifier;
                explosionDir.Normalize();
            }

            rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
        }
    }
}
