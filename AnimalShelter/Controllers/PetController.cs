using AnimalShelter.Controllers;
using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace AnimalShelterWPF.ViewModels
{
    public class PetViewModel : ViewModelBase
    {
        private int idPet;
        public int IdPet
        {
            get => idPet;
            set => SetProperty(ref idPet, value);
        }

        private string? name;
        public string? Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string? race;
        public string? Race
        {
            get => race;
            set => SetProperty(ref race, value);
        }

        private int? age;
        public int? Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }

        private char? genre;
        public char? Genre
        {
            get => genre;
            set => SetProperty(ref genre, value);
        }

        private TimeOnly? dateEntry;
        public TimeOnly? DateEntry
        {
            get => dateEntry;
            set => SetProperty(ref dateEntry, value);
        }

        private string? medicalHistory;
        public string? MedicalHistory
        {
            get => medicalHistory;
            set => SetProperty(ref medicalHistory, value);
        }

        private char? status;
        public char? Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        private int? idShelter;
        public int? IdShelter
        {
            get => idShelter;
            set => SetProperty(ref idShelter, value);
        }

        private string? especie;
        private string Especie
        {
            get => especie;
            set=>SetProperty(ref especie, value);
        }
        public ObservableCollection<Adoption> Adoptions { get; set; } = new ObservableCollection<Adoption>();
        public ObservableCollection<Appointment> Appointments { get; set; } = new ObservableCollection<Appointment>();

        private Shelter? idShelterNavigation;
        public Shelter? IdShelterNavigation
        {
            get => idShelterNavigation;
            set => SetProperty(ref idShelterNavigation, value);
        }

        private ObservableCollection<Pet> pets;
        public ObservableCollection<Pet> Pets
        {
            get => pets;
            set
            {
                if (SetProperty(ref pets, value))
                {
                    _filteredPets = CollectionViewSource.GetDefaultView(pets);
                    _filteredPets.Filter = FilterPets;
                }
            }
        }

        private ICollectionView _filteredPets;
        public ICollectionView FilteredPets => _filteredPets;

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    _filteredPets.Refresh();
                }
            }
        }
        private string _ageFilter;
        public string AgeFilter
        {
            get => _ageFilter;
            set
            {
                if (SetProperty(ref _ageFilter, value))
                {
                    _filteredPets.Refresh();
                }
            }
        }
        private string _imgItem;
        public string ImagItem
        {
            get => _imgItem;
            set => SetProperty(ref _imgItem, value);
        }
        public PetViewModel()
        {
            LoadPets();
            _filteredPets = CollectionViewSource.GetDefaultView(pets);
            _filteredPets.Filter = FilterPets;
            _searchText = string.Empty;
        }

        public void LoadPets()
        {
            using (var context = new ApplicationContext())
            {
                List<Pet> petList = context.Pets.ToList();
                Pets = new ObservableCollection<Pet>(petList);
            }
        }

        private void ExecuteSearch(object parameter)
        {
            _filteredPets.Refresh();
        }

        private bool FilterPets(object obj)
        {
            if (obj is Pet pet)
            {
                return string.IsNullOrEmpty(SearchText) || pet.Name.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ;
            }
            return false;
        }

    }
}
