using Game.Characters;
using Game.Interaction;
using UnityEngine;

namespace Game.Obstacles
{
    public abstract class WorldContentSO : ScriptableObject
    {

    }

    public class ObstacleWorldContentSO : WorldContentSO
    {
        [SerializeField, Min(0f)] private float _strength;
    }
    public class Obstacle : InteractableByCharacterComponent
    {
        private readonly ObstacleWorldContentSO _reference;

        protected override void HandleInteraction(Character interactor)
        {
            
        }
    }
}
