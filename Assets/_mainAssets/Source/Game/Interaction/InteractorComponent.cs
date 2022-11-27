using System;
using Game.Characters;
using Game.Helpers;
using Game.Interaction;
using UnityEngine;
using Utils.Interaction;

namespace Game
{
    [RequireComponent(typeof(Collider2D), typeof(Character))]
    public class InteractorComponent : MonoBehaviour
    {
        private Character _character;
        private Collider2D _collider;

        private static ContactFilter2D _contactFilter2D;
        private static readonly Collider2D[] _buffer = new Collider2D[1024];
        private static readonly ReadOnlyMemory<Collider2D> _memBuffer = new(_buffer);


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Init()
        {
            _contactFilter2D = new ContactFilter2D
            {
                layerMask = FastAccess.Interactables,
                useDepth = false,
                useLayerMask = true,
                useTriggers = true,
            };
        }


        private void Awake()
        {
            _character = GetComponent<Character>();
            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            var overlapsCount = _collider.OverlapCollider(_contactFilter2D, _buffer);

            if (overlapsCount == 0)
                return;

            var span = _memBuffer[..overlapsCount].Span;

            for (int i = -1; ++i < overlapsCount;)
            {
                var col = span[i];

                if (col.TryGetComponent<InteractableComponent<Character>>(out var interactable))
                    interactable.Interact(_character);
            }
        }
    }
}
