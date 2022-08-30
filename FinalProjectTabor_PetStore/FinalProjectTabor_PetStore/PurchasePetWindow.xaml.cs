using System;
using System.Windows;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Window used to purchase a pet.
    /// </summary>
    public partial class PurchasePetWindow : Window
    {
        public Animal animal;

        public Person Owner;

        public IAnimalFactory animalFactory;

        public PurchasePetWindow(Person owner)
        {
            this.InitializeComponent();

            Owner = owner;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.animalTypeComboBox.ItemsSource = Enum.GetValues(typeof(AnimalTypes));
            this.colorComboBox.ItemsSource = Enum.GetValues(typeof(Colors));
        }

        /// <summary>
        /// Uses the correct animal factory to create an animal and return it to the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (animalTypeComboBox.SelectedItem != null
                && colorComboBox.SelectedItem != null
                && nameTextBox.Text != null)
            {
                AnimalTypes animalType = (AnimalTypes)animalTypeComboBox.SelectedItem;
                Colors color = (Colors)colorComboBox.SelectedItem;
                string name = nameTextBox.Text;

                switch (animalType)
                {
                    case AnimalTypes.Dog:
                        animalFactory = new MammalFactory();
                        animal = animalFactory.Create(name, animalType, color, Owner);
                        MessageBox.Show($"{name} will run away if food bowl level hits 0, use the feed animal button to refill bowl.");
                        break;

                    case AnimalTypes.Cat:
                        animalFactory = new MammalFactory();
                        animal = animalFactory.Create(name, animalType, color, Owner);
                        MessageBox.Show($"{name} will run away if litter box level hits 0, use the bathroom button to clean litter box.");
                        break;

                    case AnimalTypes.GoldFish:
                        animalFactory = new FishFactory();
                        animal = animalFactory.Create(name, animalType, color, Owner);
                        MessageBox.Show($"{name} will run away if bowl cleanliness hits 0, use the bathroom button to clean bowl.");
                        break;

                    case AnimalTypes.Turtle:
                        animalFactory = new ReptileFactory();
                        animal = animalFactory.Create(name, animalType, color, Owner);
                        MessageBox.Show($"{name} will run away if boredom level hits 5, play with {name} to lower level.");
                        break;

                    case AnimalTypes.Parrot:
                        animalFactory = new BirdFactory();
                        animal = animalFactory.Create(name, animalType, color, Owner);
                        MessageBox.Show($"{name} will run away if seeds level hits 0, use the food button to refill seed.");
                        break;
                }

                if (animal != null)
                {
                    DialogResult = true;
                }
            }
            else
            {
                MessageBox.Show("Every field must be complete to purchase pet.");
            }
        }
    }
}
