using Game.Characters;

namespace Game.Interaction
{
    public class TestInteractableByCharacterComponene : InteractableByCharacterComponent
    {
        protected override void HandleInteraction(Character interactor)
        {
            UnityEngine.Debug.Log("000000");
        }
    }
}
