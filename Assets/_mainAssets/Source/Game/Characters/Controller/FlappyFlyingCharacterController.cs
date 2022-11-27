using System;
using UnityEngine;

namespace Game.Characters.Controller
{
    public class FlappyFlyingCharacterController : MonoBehaviour, IFlappyFlyingCharacterController
    {
        [SerializeField] private float _strafeHeight = 1.6f;
        [SerializeField] private float _strafeTime = 0.5f;
        [Tooltip("Minus Gravity")]
        [SerializeField, Min(0f)] private float _downForce = 14f;

        private ControllerCorrector _corrector;
        private const float _maxHorizontalSpeed = 50f;
        private const float _maxVerticalSpeed = 30f;

        private float _horizontalVelocity;
        private float _verticalVelocity;


        public Vector2 Velocity => new(_horizontalVelocity, _verticalVelocity);
        public float Speed => (float)System.Math.Sqrt(_horizontalVelocity * _horizontalVelocity + _verticalVelocity * _verticalVelocity);


        public event System.Action<IFlappyFlyingCharacterController, Vector3> OnPositionChanged;


        public void SetPositionCorrector(ControllerCorrector corrector)
        {
            _corrector = corrector;
        }


        public void SetVelocity(Vector2 velocity)
        {
            _horizontalVelocity = velocity.x;
            _verticalVelocity = velocity.y;
        }

        public void SetVelocityX(float x) => _horizontalVelocity = x;

        public void SetVelocityY(float y) => _verticalVelocity = y;


        public void StrafeUp()
        {
            Debug.Log("strafe up");
            //_verticalVelocity += Mathf.Sqrt(_strafeHeight * 2 * _downForce);
            _verticalVelocity = Mathf.Sqrt(_strafeHeight * 2 * _downForce);
        }


        private void Update()
        {
            ApplyDownForce();
            EnsureSpeedsLimits();
            Move();
        }

        private void EnsureSpeedsLimits()
        {
            _horizontalVelocity = Math.Clamp(_horizontalVelocity, -_maxHorizontalSpeed, _maxHorizontalSpeed);
            _verticalVelocity = Math.Clamp(_verticalVelocity, -_maxVerticalSpeed, _maxVerticalSpeed);
        }

        private void ApplyDownForce()
        {
            _verticalVelocity -= _downForce * Time.deltaTime;
        }

        private void Move()
        {
            var newP = transform.position + new Vector3(_horizontalVelocity, _verticalVelocity, 0) * Time.deltaTime;

            if (_corrector != null)
                newP = _corrector.Invoke(this, newP);

            transform.position = newP;
            OnPositionChanged?.Invoke(this, newP);
        }
    }
}
