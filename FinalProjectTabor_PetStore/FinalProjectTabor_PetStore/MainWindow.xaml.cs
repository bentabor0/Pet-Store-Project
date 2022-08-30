using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FinalProjectTabor_PetStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person Person = new Person();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Person.OnTextUpdate += PopulateListBox;
        }

        private void PopulateListBox()
        {
            this.Dispatcher.Invoke(new Action(delegate ()
            {
                PetsListBox.ItemsSource = null;
                PetsListBox.ItemsSource = Person.pets;
            }));
        }

        public void LoadPets(List<Animal> pets)
        {
            foreach (Animal a in pets)
            {
                a.RegisterObserver(Person);
                Person.AddPet(a);
                a.SetTimer();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PurchasePetWindow purchasePetWindow = new PurchasePetWindow(Person);

            purchasePetWindow.ShowDialog();

            if (purchasePetWindow.DialogResult == true)
            {
                purchasePetWindow.animal.RegisterObserver(Person);
                Person.AddPet(purchasePetWindow.animal);
            }
        }

        private void PlayWithPetButton_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = (Animal)PetsListBox.SelectedItem;

            if (animal != null)
            {
                Person.PlayWithPet(animal);
            }
            else
            {
                MessageBox.Show("Please select an animal to play with.");
            }
        }

        private void FeedPetButton_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = (Animal)PetsListBox.SelectedItem;

            if (animal != null)
            {
                Person.FeedPet(animal);
            }
            else
            {
                MessageBox.Show("Please select an animal to feed.");
            }
        }

        private void BathroomButton_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = (Animal)PetsListBox.SelectedItem;

            if (animal != null)
            {
                Person.PetBathroom(animal);
            }
            else
            {
                MessageBox.Show("Please select an animal to use the bathroom.");
            }
        }

        private void HelpSleepButton_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = (Animal)PetsListBox.SelectedItem;

            if (animal != null)
            {
                Person.PutPetToSleep(animal);
            }
            else
            {
                MessageBox.Show("Please select an animal to sleep.");
            }
        }

        private void SavePetsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pet save-game files (*pets)|*.pets";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                SaveAndLoadPets.SaveToFile(saveFileDialog.FileName, Person);
            }
        }

        private void LoadPetsButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pet save-game files (*pets)|*.pets";
            openFileDialog.ShowDialog();

            List<Animal> loadedPets = new List<Animal>();

            if (openFileDialog.ShowDialog() == true)
            {
                loadedPets = SaveAndLoadPets.LoadFromFile(openFileDialog.FileName);
            }

            LoadPets(loadedPets);
        }

        private void PetsListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }
    }
}
