using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Abstract animal class. Animal holds all common behaviors and methods for sub animals. Animal is the Subject for Observer class to subsribe to.
    /// </summary>
    [Serializable]
    public abstract class Animal : ISubject
    {
        [NonSerialized]
        private IObserver observer;

        [NonSerialized]
        public Person owner;

        public Animal(string name, Person owner)
        {
            this.Name = name;
            this.owner = owner;
        }

        [NonSerialized]
        public Timer Timer;

        public string Name { get; set; }

        public int HappinessLevel { get; set; }

        public int HungerLevel { get; set; }

        public int BathroomLevel { get; set; }

        public int EnergyLevel { get; set; }

        public List<Toys> toys { get; set; }

        public abstract void Eat(bool withOwner);

        public abstract void Sleep(bool withOwner);

        public abstract void Play(bool withOwner);

        public abstract void UseBathroom(bool withOwner);

        public void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Animal will play with themselves if happiness level gets below 10.
            if (HappinessLevel <= 0)
            {
                Play(false);
            }
            else
            {
                HappinessLevel -= 2;
            }

            // Animal will eat if hunger level reaches 100.
            if (HungerLevel >= 100)
            {
                Eat(false);
            }
            else
            {
                HungerLevel += 2;
            }

            // Animal will use bathroom  if bathroom level reaches 100.
            if (BathroomLevel >= 100)
            {
                UseBathroom(false);
            }
            else
            {
                BathroomLevel += 2;
            }

            // Animal will take a nap when energy level reaches 0.
            if (EnergyLevel <= 0)
            {
                Sleep(false);
            }
            else
            {
                EnergyLevel -= 2;
            }

            NotifyObservers();
        }

        public void SetTimer()
        {
            this.Timer = new System.Timers.Timer(5000);
            this.Timer.Elapsed += Timer_Elapsed;
            this.Timer.Start();
        }

        public override string ToString()
        {
            return $"{this.Name} : {this.GetType().Name} | Happiness: {this.HappinessLevel} | Hunger: {this.HungerLevel} | Energy: {this.EnergyLevel} | Bathroom Level: {this.BathroomLevel}";
        }

        public void RegisterObserver(IObserver o)
        {
            observer = o;
        }

        public void RemoveObserver(IObserver o)
        {
            observer = null;
        }

        public void NotifyObservers()
        {
            if (observer != null)
            {
                observer.Update();
            }
        }
    }
}
