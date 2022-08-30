using System;
using System.Windows;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Cat runs away if litter box is not cleaned.
    /// </summary>
    [Serializable]
    public class Cat : Animal
    {
        public Colors Fur { get; set; }

        public int LitterBoxLevel { get; set; }

        public Cat(string name, Colors furColor, Person owner)
            : base(name, owner)
        {
            Fur = furColor;
            SetTimer();
            LitterBoxLevel = 10;
        }

        public override void UseBathroom(bool withOwner)
        {
            if (LitterBoxLevel <= 0)
            {
                owner.RemovePet(this);
                RemoveObserver(owner);
                MessageBox.Show($"{this.Name} had no where to pee so they ran away.");
            }
            else
            {
                if (withOwner == true)
                {
                    BathroomLevel = 0;
                    LitterBoxLevel = 10;
                    MessageBox.Show($"You let {this.Name} outside to use the bathroom and cleaned the litter box.");
                }
                else
                {
                    BathroomLevel = 0;
                    LitterBoxLevel--;
                    MessageBox.Show($"{this.Name} pooped in the litter box");
                }
            }

            NotifyObservers();
        }

        public override void Eat(bool withOwner)
        {
            if (withOwner == true)
            {
                HungerLevel = 0;
                HappinessLevel += 20;
                MessageBox.Show($"You gave {this.Name} some wet cat food.");
            }
            else
            {
                HungerLevel = 0;
                MessageBox.Show($"{this.Name} ate some kibble.");
            }

            NotifyObservers();
        }

        public override void Play(bool withOwner)
        {
            if (withOwner == true)
            {
                HappinessLevel = 100;
                MessageBox.Show($"You and {this.Name} played with a lazer pointer.");
            }
            else
            {
                HappinessLevel += 40;
                MessageBox.Show($"{this.Name} scratched up the couch.");
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
                MessageBox.Show($"{this.Name} fell asleep by the window.");
            }

            NotifyObservers();
        }

        public override string ToString()
        {
            return base.ToString() + $" | Litter Box Level: {this.LitterBoxLevel}";
        }
    }
}
