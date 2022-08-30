using System;
using System.Windows;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Turtle runs away if it get bored.
    /// </summary>
    [Serializable]
    public class Turtle : Animal
    {
        public Colors Shell { get; set; }

        public int BoredomLevel { get; set; }

        public Turtle(string name, Colors shellColor, Person owner)
            : base(name, owner)
        {
            Shell = shellColor;
            SetTimer();
            BoredomLevel = 0;
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
                MessageBox.Show($"{this.Name} pooped in their cage");
            }

            NotifyObservers();
        }

        public override void Eat(bool withOwner)
        {
            if (withOwner == true)
            {
                HungerLevel = 0;
                HappinessLevel += 50;
                MessageBox.Show($"You gave {this.Name} a big beetle.");
            }
            else
            {
                HungerLevel = 0;
                MessageBox.Show($"{this.Name} ate turtle pellets.");
            }

            NotifyObservers();
        }

        public override void Play(bool withOwner)
        {
            if (BoredomLevel >= 5)
            {
                owner.RemovePet(this);
                RemoveObserver(owner);
                MessageBox.Show($"{this.Name} got tired of chewing on his toy and left.");
            }
            else
            {
                if (withOwner == true)
                {
                    HappinessLevel = 100;
                    BoredomLevel = 0;
                    MessageBox.Show($"You placed {this.Name} in a pool in the backyard.");
                }
                else
                {
                    HappinessLevel += 30;
                    BoredomLevel++;
                    MessageBox.Show($"{this.Name} chewed on a toy.");
                }
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
                MessageBox.Show($"{this.Name} fell asleep in the cage.");
            }

            NotifyObservers();
        }

        public override string ToString()
        {
            return base.ToString() + $" | Boredom Level: {this.BoredomLevel}";
        }
    }
}
