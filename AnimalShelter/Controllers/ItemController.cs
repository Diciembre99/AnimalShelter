using AnimalShelter.Controllers;
using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace AnimalShelter.Controllers
{
    public class ItemController : ViewModelBase
    {
        private ObservableCollection<Item> items;
        private int idItem;
        private string? name;
        private int? stock;
        private string? typeItem;
        private string imgItem;
        private string? animalType;
        private int? idShelter;
        private char? status;
        private float? price;
        private Shelter? idShelterNavigation;
        private ICollectionView _filteredItems;
        private string? description;
        private string _searchText;
        private bool _isSnackbarActive;

        public int IdItem
        {
            get => idItem;
            set => SetProperty(ref idItem, value);
        }

        public string? Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public int? Stock
        {
            get => stock;
            set => SetProperty(ref stock, value);
        }

        public string? TypeItem
        {
            get => typeItem;
            set => SetProperty(ref typeItem, value);
        }

        public string? AnimalType
        {
            get => animalType;
            set => SetProperty(ref animalType, value);
        }

        public int? IdShelter
        {
            get => idShelter;
            set => SetProperty(ref idShelter, value);
        }

        public char? Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        public float? Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string? Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Shelter? IdShelterNavigation
        {
            get => idShelterNavigation;
            set => SetProperty(ref idShelterNavigation, value);
        }

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

        public string ImagItem
        {
            get => imgItem;
            set => SetProperty(ref imgItem, value);
        }

        public ICollectionView FilteredItems => _filteredItems;

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

        public Visibility _isProgressBarVisible;
        public Visibility IsProgressBarVisible
        {
            get => _isProgressBarVisible;
            set => SetProperty(ref  _isProgressBarVisible, value);
        }
        public ItemController()
        {
            items = new ObservableCollection<Item>();
            _filteredItems = CollectionViewSource.GetDefaultView(items);
            _filteredItems.Filter = FilterItems;
            _searchText = string.Empty;
            SearchCommand = new RelayCommand(ExecuteSearch);
            SaveCommand = new RelayCommand(_ => SaveItem());
            DeleteItemCommand = new RelayCommand(ExecuteDeleteItem);

        }
        public ICommand SearchCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteItemCommand { get; private set; }



        public async Task<bool> LoadItems()
        {
            try
            {
                using (var context = new ApplicationContext())
                {
                    List<Item>itemList = await context.Items.ToListAsync();
                    Items = new ObservableCollection<Item>(itemList);
                    return true;
                }
            }
            catch (Exception) {
                return false;
            }


        }
        public bool IsSnackbarActive
        {
            get => _isSnackbarActive;
            set => SetProperty(ref _isSnackbarActive, value);
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
        private void SaveItem()
        {
            try
            {
                using (var context = new ApplicationContext())
                {
                    foreach (Item item in Items)
                    {
                        context.Items.Update(item);
                    }
                    context.SaveChanges();

                    
                }

            }
            catch (Exception ex)
            {
                
            }
                    IsSnackbarActive = false;
        }

        private void ExecuteDeleteItem(object parameter)
        {
            if (parameter is Item itemToDelete)
            {
                using (var context = new ApplicationContext())
                {
                    context.Items.Remove(itemToDelete);
                    context.SaveChanges(); 
                }
                LoadItems(); 
            }
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
