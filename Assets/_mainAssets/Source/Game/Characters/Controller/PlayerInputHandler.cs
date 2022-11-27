using System;
using UnityEngine;

namespace Game.Characters.Controller
{

    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private FlappyFlyingCharacterController _controller;
        [SerializeField] private RectTransform[] _blockingRects;

        private float _speed;
        private float _speedIncreasingRate = 0.1f;

        private float _minSpeed = 0.3f;
        private float _maxSpeed = 30f;

        private void Update()
        {
            _speed = System.Math.Clamp(_speed + Time.deltaTime * _speedIncreasingRate, _minSpeed, _maxSpeed);
            _controller.SetVelocityX(_speed);

            if (!CheckForInputsReceiving())
                return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (!CheckForBlockingClick())
                    _controller.StrafeUp();
            }
        }


        private bool CheckForInputsReceiving()
        {
            return !EasyGameStateProvider.IsPaused
                && EasyGameStateProvider.IsPlayerAlive;
        }

        private bool CheckForBlockingClick()
        {
            Vector2 clickPos = Input.mousePosition;

            foreach (var rt in _blockingRects)
            {
                if (rt.rect.Contains(clickPos))
                    return true;
            }

            return false;
        }
    }
}
