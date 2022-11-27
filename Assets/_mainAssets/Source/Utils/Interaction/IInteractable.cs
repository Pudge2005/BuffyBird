namespace Utils.Interaction
{
    public interface IInteractable<TInteractor>
    {
        void Interact(TInteractor interactor);
    }
}
