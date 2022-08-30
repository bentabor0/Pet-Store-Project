using System;
using System.Windows;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Parrot runs away if seeds are not refilled.
    /// </summary>
    [Serializable]
    public class Parrot : Animal
    {
        public Colors Feathers { get; set; }

        public int SeedsLevel { get; set; }

        public Parrot(string name, Colors featherColor, Person owner)
            : base(name, owner)
        {
            Feathers = featherColor;
            SetTimer();
            SeedsLevel = 10;
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
                MessageBox.Show($"{this.Name} pooped in the the bird cage.");
            }

            NotifyObservers();
        }

        public override void Eat(bool withOwner)
        {
            if (SeedsLevel <= 0)
            {
                owner.RemovePet(this);
                RemoveObserver(owner);
                MessageBox.Show($"{this.Name} flew away to find more strawberries.");
            }
            else
            {
                if (withOwner == true)
                {
                    HungerLevel = 0;
                    HappinessLevel += 30;
                    SeedsLevel = 10;
                    MessageBox.Show($"You gave {this.Name} a strawberry and filled the cage with seeds.");
                }
                else
                {
                    HungerLevel = 90;
                    SeedsLevel--;
                    MessageBox.Show($"{this.Name} ate some seeds.");
                }
            }

            NotifyObservers();
        }

        public override void Play(bool withOwner)
        {
            if (withOwner == true)
            {
                HappinessLevel = 100;
                MessageBox.Show($"You talked with {this.Name}.");
            }
            else
            {
                HappinessLevel += 10;
                MessageBox.Show($"{this.Name} talked to themself.");
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
            return base.ToString() + $" | Seeds Level: {this.SeedsLevel}";
        }
    }
}
