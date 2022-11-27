using UnityEngine;

namespace Utils.Shake
{
    public static class RandomHelpers
    {
        public static Vector2 PointOnCircle(System.Random rndInst)
        {
            double angle = rndInst.NextDouble() * System.Math.PI * 2;
            Vector2 p;
            p.x = (float)System.Math.Cos(angle);
            p.y = (float)System.Math.Sin(angle);
            return p;
        }
    }
    public sealed class CameraJuice : MonoBehaviour
    {
        [SerializeField] private float _adjustTime = 0.4f;

        [SerializeField] private AnimationCurve _fovCurve;

        [SerializeField] private float _minFov;
        [SerializeField] private float _maxFov;

        private Camera _cam;
        private Transform _camTr;
        private float _defaultFov;


        private void Awake()
        {
            _cam = Camera.main;
            _camTr = _cam.transform;

            _defaultFov = _cam.orthographic ? _cam.orthographicSize : _cam.fieldOfView;
        }


        private void Update()
        {
            float speed = 15f;
            float minSpeed = 0f;
            float maxSpeed = 30f;
            float t = Mathf.InverseLerp(minSpeed, maxSpeed, speed);

            //skip smooth time

            var fov = _defaultFov * _fovCurve.Evaluate(t);
            fov = System.Math.Clamp(fov, _minFov, _maxFov);
            SetFov(fov);

        }

        private void SetFov(float v)
        {
            if (_cam.orthographic)
            {
                _cam.orthographicSize = v;
            }
            else
            {
                _cam.fieldOfView = v;
            }
        }
    }

}