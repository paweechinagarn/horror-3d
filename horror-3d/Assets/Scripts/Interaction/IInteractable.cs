namespace Horror3D
{
    public interface IInteractable
    {
        InteractionAmountMode AmountMode { get; }
        void Interact();
    }
}
