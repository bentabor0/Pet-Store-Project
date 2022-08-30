using System;
using System.Windows;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Dog runs away if food bowl is not filled.
    /// </summary>
    [Serializable]
    public class Dog : Animal
    {
        public Colors Fur { get; set; }

        public int FoodBowlLevel { get; set; }

        public Dog(string name, Colors furColor, Person owner)
            : base(name, owner)
        {
            Fur = furColor;
            SetTimer();
            FoodBowlLevel = 5;
        }

        public override void UseBathroom(bool withOwner)
        {
            if (withOwner == true)
            {
                BathroomLevel = 0;
                MessageBox.Show($"You let {this.Name} outside to use the bathroom.");
            }
            else
            {
                BathroomLevel = 0;
                MessageBox.Show($"{this.Name} pooped on the carpet");
            }

            NotifyObservers();
        }

        public override void Eat(bool withOwner)
        {
            if (FoodBowlLevel <= 0)
            {
                owner.RemovePet(this);
                RemoveObserver(owner);
                MessageBox.Show($"{this.Name} had no food and ran away to find some.");
            }
            else
            {
                if (withOwner == true)
                {
                    HungerLevel = 0;
                    HappinessLevel += 40;
                    FoodBowlLevel = 5;
                    MessageBox.Show($"You gave {this.Name} a scrambled egg and filled the food bowl.");
                }
                else
                {
                    HungerLevel = 0;
                    FoodBowlLevel--;
                    MessageBox.Show($"{this.Name} ate some dog food.");
                }
            }

            NotifyObservers();
        }

        public override void Play(bool withOwner)
        {
            if (withOwner == true)
            {
                HappinessLevel = 100;
                BathroomLevel -= 50;
                MessageBox.Show($"You took {this.Name} for a walk and played fetch.");
            }
            else
            {
                HappinessLevel += 50;
                MessageBox.Show($"{this.Name} destroyed your shoes.");
            }

            NotifyObservers();
        }

        public override void Sleep(bool withOwner)
        {
            if (withOwner == true)
            {
                EnergyLevel = 100;
                HappinessLevel += 20;
                MessageBox.Show($"You tucked {this.Name} in for bed.");
            }
            else
            {
                EnergyLevel = 100;
                MessageBox.Show($"{this.Name} fell asleep in the couch.");
            }

            NotifyObservers();
        }

        public override string ToString()
        {
            return base.ToString() + $" | Food Bowl Level: {this.FoodBowlLevel}";
        }
    }
}
