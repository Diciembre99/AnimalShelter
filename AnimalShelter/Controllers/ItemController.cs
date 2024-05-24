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
    public class ItemController : ViewModelBase
    {
        private int idItem;
        public int IdItem
        {
            get => idItem;
            set => SetProperty(ref idItem, value);
        }

        private string? name;
        public string? Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private int? stock;
        public int? Stock
        {
            get => stock;
            set => SetProperty(ref stock, value);
        }

        private string? typeItem;
        public string? TypeItem
        {
            get => typeItem;
            set => SetProperty(ref typeItem, value);
        }

        private string? animalType;
        public string? AnimalType
        {
            get => animalType;
            set => SetProperty(ref animalType, value);
        }

        private int? idShelter;
        public int? IdShelter
        {
            get => idShelter;
            set => SetProperty(ref idShelter, value);
        }

        private char? status;
        public char? Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        private float? price;
        public float? Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        private string? description;
        public string? Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private Shelter? idShelterNavigation;
        public Shelter? IdShelterNavigation
        {
            get => idShelterNavigation;
            set => SetProperty(ref idShelterNavigation, value);
        }

        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
        {
            get => items;
            set
            {
                if (SetProperty(ref items, value))
                {
                    _filteredItems = CollectionViewSource.GetDefaultView(items);
                    _filteredItems.Filter = FilterItems;
                }
            }
        }

        private ICollectionView _filteredItems;
        public ICollectionView FilteredItems => _filteredItems;

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    _filteredItems.Refresh();
                }
            }
        }

        public ICommand SearchCommand { get; }

        public ItemController()
        {
            items = new ObservableCollection<Item>();
            _filteredItems = CollectionViewSource.GetDefaultView(items);
            _filteredItems.Filter = FilterItems;
            _searchText = string.Empty;
            LoadItems();
            SearchCommand = new RelayCommand(ExecuteSearch);
        }

        public void LoadItems()
        {
            using (var context = new ApplicationContext())
            {
                var itemList = context.Items.ToList();
                Items = new ObservableCollection<Item>(itemList);
            }
        }

        private void ExecuteSearch(object parameter)
        {
            _filteredItems.Refresh();
        }

        private bool FilterItems(object obj)
        {
            if (obj is Item item)
            {
                return string.IsNullOrEmpty(SearchText) || item.Name.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            return false;
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
