using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Factory to create reptiles.
    /// </summary>
    public class ReptileFactory : IAnimalFactory
    {
        private Animal reptile;

        public Animal Create(string name, AnimalTypes type, Colors color, Person owner)
        {
            switch (type)
            {
                case AnimalTypes.Turtle:
                    reptile = new Turtle(name, color, owner);
                    break;
            }

            GiveToys(reptile, type);
            SetStartState(reptile);

            return reptile;
        }

        public void GiveToys(Animal reptile, AnimalTypes type)
        {
            switch (type)
            {
                case AnimalTypes.Turtle:
                    reptile.toys = new List<Toys> { Toys.KiddyPool };
                    break;
            }
        }

        public void SetStartState(Animal a)
        {
            a.HappinessLevel = 30;
            a.HungerLevel = 70;
            a.EnergyLevel = 10;
            a.BathroomLevel = 20;
        }
    }
}
