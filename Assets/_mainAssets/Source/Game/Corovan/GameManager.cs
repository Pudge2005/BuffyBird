using UnityEngine;

namespace Game.Characters.Controller
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Transform _lowestPoint;
        [SerializeField] private Transform _highestPoint;

        [SerializeField] private FlappyFlyingCharacterController _playerCharacterController;


        private void Awake()
        {
            _playerCharacterController.SetPositionCorrector(CorrectCharacterPosition);
        }

        private Vector3 CorrectCharacterPosition(IFlappyFlyingCharacterController controller, Vector3 arg)
        {
            arg.y = System.Math.Clamp(arg.y, _lowestPoint.position.y, _highestPoint.position.y);
            return arg;
        }
    }
}
