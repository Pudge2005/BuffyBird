using System;
using UnityEngine;

namespace Game
{

    public class DestroyerLight : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _boxCollider;

        private static readonly ContactFilter2D _contactFilter2D = InitContactFilter();
        private static readonly Collider2D[] _buffer = new Collider2D[1024];
        private static readonly ReadOnlyMemory<Collider2D> _memBuffer = new(_buffer);


        private static ContactFilter2D InitContactFilter()
        {
            return new ContactFilter2D
            {
                layerMask = FastAccess.Destructibles,
                useDepth = false,
                useLayerMask = true,
                useTriggers = true,
            };
        }


        private void FixedUpdate()
        {
            var overlapsCount = _boxCollider.OverlapCollider(_contactFilter2D, _buffer);

            if (overlapsCount == 0)
                return;

            Vector3 p = transform.position;

            var span = _memBuffer[..overlapsCount].Span;
            for (int i = -1; ++i < overlapsCount;)
            {
                var col = span[i];

                if (col.TryGetComponent<DestructibleBase>(out var destructible))
                    destructible.Destroy(p);
            }
        }
    }
}
