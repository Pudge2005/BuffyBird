using UnityEngine;
using UnityEngine.Events;

namespace Utils.Interaction
{
    public class UnityEventInteractableComponent<TInteractor> : InteractableComponent<TInteractor>
    {
        [SerializeField] private UnityEvent _onInteract;
        [SerializeField] private UnityEvent<TInteractor> _onInteract_Interactor;


        protected override void HandleInteraction(TInteractor interactor)
        {
            _onInteract?.Invoke();
            _onInteract_Interactor?.Invoke(interactor);
        }
    }
}
