using System.Collections.Generic;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Factory for creating birds.
    /// </summary>
    public class BirdFactory : IAnimalFactory
    {
        private Animal bird;

        public Animal Create(string name, AnimalTypes type, Colors color, Person owner)
        {
            switch (type)
            {
                case AnimalTypes.Parrot:
                    bird = new Parrot(name, color, owner);
                    break;
            }

            GiveToys(bird, type);
            SetStartState(bird);

            return bird;
        }

        public void GiveToys(Animal a, AnimalTypes type)
        {
            switch (type)
            {
                case AnimalTypes.Parrot:
                    bird.toys = new List<Toys> { Toys.HangingBall };
                    break;
            }
        }

        public void SetStartState(Animal a)
        {
            a.HappinessLevel = 40;
            a.HungerLevel = 75;
            a.EnergyLevel = 100;
            a.BathroomLevel = 75;
        }
    }
}
