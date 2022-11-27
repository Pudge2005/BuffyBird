using UnityEngine;


namespace Game.Characters.Controller
{
    public delegate Vector3 ControllerCorrector(IFlappyFlyingCharacterController controller,
                                                Vector3 rawPosition);

    public interface IFlappyFlyingCharacterController
    {
        Vector2 Velocity { get; }
        float Speed { get; }

        event System.Action<IFlappyFlyingCharacterController, Vector3> OnPositionChanged;


        void SetPositionCorrector(ControllerCorrector corrector);

        void StrafeUp();

        void SetVelocity(Vector2 velocity);
        void SetVelocityX(float x);
        void SetVelocityY(float y);
    }
}
