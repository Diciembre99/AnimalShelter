using AnimalShelter.Controllers;
using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;
using Microsoft.Win32;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
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
            var notificationManager = new NotificationManager();
            txtName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(txtName) || Validation.GetHasError(txtRace) || Validation.GetHasError(dtAge) || 
                Validation.GetHasError(dtDate) || Validation.GetHasError(txtSpecies) || Validation.GetHasError(txtNumChip)||
                Validation.GetHasError(txtSize))
            {
                notificationManager.Show(new NotificationContent
                {
                    Title = "Error",
                    Message = "Error al completar los campos",
                    Type = NotificationType.Error,


                });
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
            

            char adopter;
            if (checkEsterilization.IsChecked.Value)
            {
                adopter = 't' ;
            }
            else
            {
                adopter = 'f';
            }
      
            DateTime? selectedDate = dtDate.SelectedDate;
            string dateString = selectedDate.Value.ToShortDateString();
            BitmapSource bitmapSource = (BitmapSource)imgItem.Source;
            byte[] imageBytes = BitmapSourceToBytes(bitmapSource);
            string base64String = Convert.ToBase64String(imageBytes);
            using (var context = new ApplicationContext())
            {
                var pet = new Pet {
                    Name=txtName.Text,
                    Race=txtRace.Text,
                    Age=dtAge.Text,
                    Genre= genero,
                    DateEntry=dateString,
                    Status='o',
                    IdShelter=1,
                    Description=txtDescription.Text,
                    ImgItem = base64String,
                    Size= txtSize.Text,
                    Hair= txtHair.Text,
                    Numchip =txtNumChip.Text,
                    Species = txtSpecies.Text
                };
                context.Pets.Add(pet);
                context.SaveChanges();
                notificationManager.Show(new NotificationContent
                {
                    Title = "Completado",
                    Message = "Se ha registrado correctamente",
                    Type = NotificationType.Success,


                });
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

        private byte[] BitmapSourceToBytes(BitmapSource bitmapSource)
        {
            byte[] bytes = null;
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                bytes = stream.ToArray();
            }
            return bytes;
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;
                imgItem.Source = new BitmapImage(new Uri(selectedImagePath));
            }
        }
    }
}
