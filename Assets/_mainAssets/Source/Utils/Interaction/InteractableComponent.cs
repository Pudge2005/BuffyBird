using UnityEngine;

namespace Utils.Interaction
{
    public abstract class InteractableComponent<TInteractor> : MonoBehaviour, IInteractable<TInteractor>
    {
        public void Interact(TInteractor interactor)
        {
            HandleInteraction(interactor);
        }


        protected abstract void HandleInteraction(TInteractor interactor);
    }
}
