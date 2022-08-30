using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Factory to create fish.
    /// </summary>
    public class FishFactory : IAnimalFactory
    {
        private Animal fish;

        public Animal Create(string name, AnimalTypes type, Colors color, Person owner)
        {
            switch (type)
            {
                case AnimalTypes.GoldFish:
                    fish = new GoldFish(name, color, owner);
                    break;
            }

            GiveToys(fish, type);
            SetStartState(fish);

            return fish;
        }

        public void GiveToys(Animal fish, AnimalTypes type)
        {
            switch (type)
            {
                case AnimalTypes.GoldFish:
                    fish.toys = new List<Toys> { Toys.AquariumPlants };
                    break;
            }
        }

        public void SetStartState(Animal a)
        {
            a.HappinessLevel = 25;
            a.HungerLevel = 50;
            a.EnergyLevel = 25;
            a.BathroomLevel = 5;
        }
    }
}
