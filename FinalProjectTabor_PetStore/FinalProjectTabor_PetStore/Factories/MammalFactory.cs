using System.Collections.Generic;

namespace FinalProjectTabor_PetStore
{
    public class MammalFactory : IAnimalFactory
    {
        /// <summary>
        /// Factory to create mammals.
        /// </summary>
        private Animal mammal;

        public Animal Create(string name, AnimalTypes type, Colors color, Person owner)
        {
            switch (type)
            {
                case AnimalTypes.Dog:
                    mammal = new Dog(name, color, owner);
                    break;

                case AnimalTypes.Cat:
                    mammal = new Cat(name, color, owner);
                    break;
            }

            GiveToys(mammal, type);
            SetStartState(mammal);

            return mammal;
        }

        public void GiveToys(Animal mammal, AnimalTypes type)
        {
            switch (type)
            {
                case AnimalTypes.Dog:
                    mammal.toys = new List<Toys> { Toys.Ball, Toys.Leash, Toys.Rope };
                    break;

                case AnimalTypes.Cat:
                    mammal.toys = new List<Toys> { Toys.YarnBall, Toys.LazerPointer };
                    break;
            }
        }

        public void SetStartState(Animal mammal)
        {
            mammal.HappinessLevel = 90;
            mammal.HungerLevel = 50;
            mammal.EnergyLevel = 75;
            mammal.BathroomLevel = 50;
        }
    }
}
