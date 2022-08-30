using System;
using System.Windows;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Gold fish runs away if bowl is not cleaned.
    /// </summary>
    [Serializable]
    public class GoldFish : Animal
    {
        public Colors Scales { get; set; }

        public int BowlCleanliness { get; set; }

        public GoldFish(string name, Colors scaleColor, Person owner)
            : base(name, owner)
        {
            Scales = scaleColor;
            SetTimer();
            BowlCleanliness = 10;
        }

        public override void UseBathroom(bool withOwner)
        {
            if (BowlCleanliness <= 0)
            {
                owner.RemovePet(this);
                RemoveObserver(owner);
                MessageBox.Show($"{this.Name}'s bowl was so dirty they packed up and left for a pond.");
            }
            else
            {
                if (withOwner == true)
                {
                    BathroomLevel = 0;
                    HappinessLevel += 20;
                    BowlCleanliness = 10;
                    MessageBox.Show($"You cleaned {this.Name} bowl.");
                }
                else
                {
                    BathroomLevel = 0;
                    BowlCleanliness--;
                    MessageBox.Show($"{this.Name} pooped in the fish bowl.");
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
                MessageBox.Show($"You gave {this.Name} fish snacks.");
            }
            else
            {
                HungerLevel = 0;
                MessageBox.Show($"{this.Name} ate some algae.");
            }

            NotifyObservers();
        }

        public override void Play(bool withOwner)
        {
            if (withOwner == true)
            {
                HappinessLevel = 100;
                MessageBox.Show($"You set up an obstacle course for {this.Name}.");
            }
            else
            {
                HappinessLevel += 40;
                MessageBox.Show($"{this.Name} swam in circles.");
            }

            NotifyObservers();
        }

        public override void Sleep(bool withOwner)
        {
            if (withOwner == true)
            {
                EnergyLevel = 100;
                HappinessLevel += 20;
                MessageBox.Show($"You turned of the light for {this.Name}.");
            }
            else
            {
                EnergyLevel = 100;
                MessageBox.Show($"{this.Name} fell asleep.");
            }

            NotifyObservers();
        }

        public override string ToString()
        {
            return base.ToString() + $" | Bowl Cleanliness: {BowlCleanliness}";
        }
    }
}
