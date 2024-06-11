using AnimalShelter.Controllers;
using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AnimalShelter.Models
{
    /// <summary>
    /// Lógica de interacción para AddDonation.xaml
    /// </summary>
    public partial class AddDonation : UserControl
    {
        DonationViewModel donationView = new DonationViewModel(); 
        public AddDonation()
        {
            InitializeComponent();
            DataContext = donationView;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var notificationManager = new NotificationManager();
            try
            {
                if(Validation.GetHasError(txtName) || Validation.GetHasError(txtQuantity) || Validation.GetHasError(txtType))
                {
                    notificationManager.Show(new NotificationContent
                    {
                        Title = "Error",
                        Message = "Error al completar los campos",
                        Type = NotificationType.Error,
                    });
                    return;
                }
                else
                {
                    DateTime? selectedDate = dtDate.SelectedDate;
                    string dateString = selectedDate.Value.ToShortDateString();

                    using (var context = new ApplicationContext())
                    {
                        var donation = new Donation
                        {
                            Donor = txtName.Text,
                            Quantity = decimal.Parse(txtQuantity.Text),
                            TypeDonation = txtType.Text,
                            DateDonation = dateString,
                            IdShelter = 1

                        };
                        context.Donations.Add(donation);
                        context.SaveChanges();
                        notificationManager.Show(new NotificationContent
                        {
                            Title = "Completado",
                            Message = "Se ha agregado la donacion con exito",
                            Type = NotificationType.Success,
                        });
                    }
                }

            }catch(Exception ex) {
                notificationManager.Show(new NotificationContent
                {
                    Title = "Error",
                    Message = ex.Message,
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
    }
}
