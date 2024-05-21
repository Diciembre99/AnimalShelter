using AnimalShelterWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimalShelter.Views.Dashboard
{
    /// <summary>
    /// Lógica de interacción para Pets.xaml
    /// </summary>
    public partial class Pets : UserControl
    {
        private PetViewModel pets = new PetViewModel();
        public Pets()
        {
            InitializeComponent();
            DataContext = pets;
            pets.LoadPets();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gridPet.Children.Add(new AddPet());
        }
    }
}
