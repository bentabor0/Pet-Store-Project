using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Static class that can save and load list of pets.
    /// </summary>
    public static class SaveAndLoadPets
    {
        /// <summary>
        /// Saves a list of pets.
        /// </summary>
        /// <param name="fileName">name of file</param>
        /// <param name="person">person holding pets list</param>
        public static void SaveToFile(string fileName, Person person)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream stream = File.Create(fileName))
            {
                formatter.Serialize(stream, person.pets);
            }
        }

        /// <summary>
        /// Loads a list of pets to assign to a person.
        /// </summary>
        /// <param name="fileName">name of file.</param>
        /// <returns>list of pets</returns>
        public static List<Animal> LoadFromFile(string fileName)
        {
            List<Animal> result = null;

            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream stream = File.OpenRead(fileName))
            {
                result = formatter.Deserialize(stream) as List<Animal>;
            }

            return result;
        }
    }
}
