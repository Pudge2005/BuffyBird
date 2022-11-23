using UnityEngine;

namespace Game
{
    public class DestructiblePart : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;


        public Rigidbody2D Unbake()
        {
            _rigidbody.simulated = true;
            return _rigidbody;
        }
    }
}
