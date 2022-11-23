using UnityEngine;

namespace Game
{
    public abstract class DestructibleBase : MonoBehaviour, IDestructible
    {
        [SerializeField] private DestructiblePart[] _parts;
        [SerializeField] private float _fadeOffset = 1.4f;
        [SerializeField] private float _fadeTime = 0.8f;


        protected DestructiblePart[] Parts => _parts;
        protected float FadeOffset => _fadeOffset;
        protected float FadeTime => _fadeTime;


        public abstract void Destroy(Vector3 destroyerPosition);
    }
}
