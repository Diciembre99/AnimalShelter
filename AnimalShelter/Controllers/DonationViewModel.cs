
using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;

using System.Collections.ObjectModel;


namespace AnimalShelter.Controllers
{
      public class DonationViewModel : ViewModelBase
    {
        private string? donor;
        private string? quantity;
        private string? type;
        private ObservableCollection<Donation> donations;
        public ObservableCollection<Donation> Donations
        {
            get => donations;
            set => SetProperty(ref donations, value);
        }
        public string? Donor
        {
            get => donor;
            set => SetProperty(ref donor, value);
        }
        public string? Quantity
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }
        public string? Type
        {
            get => type;
            set => SetProperty(ref  type, value);
        }

        public DonationViewModel()
        {
            LoadDonations();
        }

        public void LoadDonations()
        {
            using (var context = new ApplicationContext())
            {
                var donationList = context.Donations.ToList();
                Donations = new ObservableCollection<Donation>(donationList);
            }
        }
    }
}
