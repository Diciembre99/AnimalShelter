using AnimalShelter.Controllers;
using AnimalShelter.Models;
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
    /// Lógica de interacción para Donation.xaml
    /// </summary>
    public partial class Donation : UserControl
    {
        DonationViewModel donationContext = new DonationViewModel();

        public Donation(User u)
        {
            InitializeComponent();
            DataContext = donationContext;
            if (u.IdCataloge==2)
            {
                btnSeeAll.Visibility = Visibility.Collapsed;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            gridDonation.Children.Add(new AddDonation());
        }

        private void btnSeeAll_Click(object sender, RoutedEventArgs e)
        {
            gridDonation.Children.Add(new DonationManage());
        }
    }
}
