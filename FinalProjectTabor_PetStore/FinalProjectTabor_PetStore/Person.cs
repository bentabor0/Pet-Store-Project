using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// The person has a list of pets which they can play, feed, let use the bathroom and put to sleep.
    /// </summary>
    public class Person : IObserver
    {
        public List<Animal> pets;

        public Person()
        {
            pets = new List<Animal>();
        }

        public void AddPet(Animal pet)
        {
            this.pets.Add(pet);
            Update();
        }

        public void RemovePet(Animal pet)
        {
            pets.Remove(pet);
            pet.Timer.Dispose();
            Update();
        }

        public void PlayWithPet(Animal pet)
        {
            pet.Play(true);
        }

        public void FeedPet(Animal pet)
        {
            pet.Eat(true);
        }

        public void PetBathroom(Animal pet)
        {
            pet.UseBathroom(true);
        }

        public void PutPetToSleep(Animal pet)
        {
            pet.Sleep(true);
        }

        public Action OnTextUpdate { get; set; }

        public void Update()
        {
            OnTextUpdate();
        }
    }
}
