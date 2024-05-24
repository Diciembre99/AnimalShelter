using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
    internal class AddItemViewModel :ViewModelBase
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string _name;
        public string _description;
        public int _stock = 0;
        public string _type;
        public float _price;

        public string? Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public int Stock
        {
            get => _stock;
            set => SetProperty(ref _stock, value);
        }
        public float Price
        {
            get => _price; 
            set => SetProperty(ref _price, value);
        }



    }
}
