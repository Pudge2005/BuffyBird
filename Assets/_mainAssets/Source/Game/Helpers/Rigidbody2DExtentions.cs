using UnityEngine;

namespace Game.Helpers
{
    public static class Rigidbody2DExtentions
    {
        public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition,
                                             float explosionRadius, float upwardsModifier)
        {
            Vector2 rbPos = rb.position;
            Vector2 explosionDir = rbPos - explosionPosition;
            float sqrDist = explosionDir.sqrMagnitude;

            float distAffect = Mathf.InverseLerp(explosionRadius * explosionRadius, 0, sqrDist);

            if (distAffect == 0)
                return;


            if (upwardsModifier != 0)
            {
                explosionDir.y += upwardsModifier;
                explosionDir.Normalize();
            }
            else
            {
                explosionDir /= (float)System.Math.Sqrt(sqrDist);
            }

            rb.AddForce(distAffect * explosionForce * explosionDir, ForceMode2D.Impulse);
        }
    }
}
