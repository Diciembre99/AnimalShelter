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
    /// Lógica de interacción para Appointments.xaml
    /// </summary>
    public partial class Appointments : UserControl
    {
        public Appointments()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            gridAppointment.Children.Add(new AddAppointment());
        }


        private void btnSeeAll_Click_1(object sender, RoutedEventArgs e)
        {
            gridAppointment.Children.Add(new UserManage());
        }
    }
}
