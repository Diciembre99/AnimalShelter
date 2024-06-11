using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;
using AnimalShelterWPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using Notifications.Wpf;
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
    /// Lógica de interacción para AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : UserControl
    {
        private PetViewModel appointment = new PetViewModel();
        public AddAppointment()
        {
            InitializeComponent();
            DataContext = appointment;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pet? selectedPet = cbPet.SelectedItem as Pet;
                string selectedDate = date.SelectedDate.Value.ToShortDateString();
                string selectedTime = time.Time.ToString();
                string title = txtName.Text + " - " + selectedPet.Name;
                var appointment = new Appointment
                {
                    Date = selectedDate,
                    Time = selectedTime,
                    Name = title,
                    Description = txtDescription.Text,
                    Veterinary = txtVeterinario.Text,
                    IdPet = selectedPet.IdPet

                };

                using (var context = new ApplicationContext())
                {
                    context.Appointments.Add(appointment);
                    context.SaveChanges();
                    var notificationManager = new NotificationManager();

                    notificationManager.Show(new NotificationContent
                    {
                        Title = "Se ha guardado correctamente",
                        Message = "La cita ha sido guardada correctamente",
                        Type = NotificationType.Success
                    });
                }
            }
            catch (DbUpdateException dbEx)
            {
                var entries = dbEx.Entries;
                foreach (var entry in entries)
                {
                    Console.WriteLine($"Entity of type {entry.Entity.GetType().Name} in state {entry.State} caused the error.");
                }

                MessageBox.Show(dbEx.Message, "Database Update Error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (dbEx.InnerException != null)
                {
                    MessageBox.Show(dbEx.InnerException.Message, "Inner Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An unexpected error occurred", MessageBoxButton.OK, MessageBoxImage.Error);
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
