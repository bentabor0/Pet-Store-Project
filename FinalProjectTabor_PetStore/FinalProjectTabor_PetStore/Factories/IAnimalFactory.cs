namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Inteface all factorys inherit. Creates common methods for each factory to use in a unique way.
    /// </summary>
    public interface IAnimalFactory
    {
        Animal Create(string name, AnimalTypes type, Colors color, Person owner);

        void SetStartState(Animal a);

        void GiveToys(Animal a, AnimalTypes type);
    }
}
