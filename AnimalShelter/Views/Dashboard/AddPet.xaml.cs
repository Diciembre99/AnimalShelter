using AnimalShelter.Controllers;
using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;
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
    /// Lógica de interacción para AddPet.xaml
    /// </summary>
    public partial class AddPet : UserControl
    {
        public AddPet()
        {
            InitializeComponent();
            DataContext = new AddPetViewModel();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            txtName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(txtName) || Validation.GetHasError(txtRace) || Validation.GetHasError(txtAge))
            {
                MessageBox.Show("There are validation errors.");
                return;
            }
            char genero;
            if (rbMale.IsChecked.Value)
            {
                genero = 'f';
            }
            else
            {
                genero = 'm';
            }
            DateTime? selectedDate = dtDate.SelectedDate;
            string dateString = selectedDate.Value.ToShortDateString();
            using (var context = new ApplicationContext())
            {
                var pet = new Pet {
                    Name=txtName.Text,
                    Race=txtRace.Text,
                    Age=txtAge.Text,
                    Genre= genero,
                    DateEntry=dateString,
                    Status='o',
                    IdShelter=1,
                    Description=txtDescription.Text
                };
                context.Pets.Add(pet);
                context.SaveChanges();
            MessageBox.Show("Save successful!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var parentGrid = this.Parent as Grid;
            if (parentGrid != null)
            {
                var parentWindow = Window.GetWindow(parentGrid);
                if (parentWindow != null)
                {
                    // Remueve este UserControl del Grid en la ventana principal
                    parentGrid.Children.Remove(this);
                }
            }
        }
    }
}
