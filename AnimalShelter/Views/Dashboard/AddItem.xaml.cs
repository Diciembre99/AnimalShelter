using AnimalShelter.Controllers;
using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;
using Microsoft.Win32;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Lógica de interacción para AddItem.xaml
    /// </summary>
    public partial class AddItem : UserControl
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var notificationManager = new NotificationManager();
            try
            {
                txtName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                if (Validation.GetHasError(txtName) || Validation.GetHasError(txtTypeItem) || Validation.GetHasError(txtPrice))
                {
                    MessageBox.Show("There are validation errors.");
                    return;
                }
                using (var context = new ApplicationContext())
                {
                    BitmapSource bitmapSource = (BitmapSource)imgItem.Source;
                    byte[] imageBytes = BitmapSourceToBytes(bitmapSource);
                    string base64String = Convert.ToBase64String(imageBytes);
                    var item = new Item
                    {
                        Name = txtName.Text,
                        Price = float.Parse(txtPrice.Text),
                        TypeItem = txtTypeItem.Text,
                        Description = txtDescription.Text,
                        Stock = (int)txtStock.Value,
                        Status = 'D',
                        IdShelter = 1,
                        ImgItem = base64String
                    };
                    context.Items.Add(item);
                    context.SaveChanges();
                    ItemController itemController = new ItemController();
                    itemController.Items.Add(item);
                    notificationManager.Show(new NotificationContent
                    {
                        Title = "Completado",
                        Message = "Se ha agregado el item con exito",
                        Type = NotificationType.Success,
                    });
                }
            }
            catch (Exception ex)
            {
                notificationManager.Show(new NotificationContent
                {
                    Title = "Error",
                    Message = "Error al completar los campos",
                    Type = NotificationType.Error,


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
        private string ConvertImageToBase64(string imagePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageArray);
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
