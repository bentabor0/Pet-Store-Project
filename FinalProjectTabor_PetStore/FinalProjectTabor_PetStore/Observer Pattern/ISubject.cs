namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Subject register and removes subsribers and notifies observers when state changes.
    /// </summary>
    public interface ISubject
    {
        void RegisterObserver(IObserver o);

        void RemoveObserver(IObserver o);

        void NotifyObservers();
    }
}
