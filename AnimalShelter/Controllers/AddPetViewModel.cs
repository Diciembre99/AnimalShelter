using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
    public class AddPetViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string _name = "Name";
        public string _race = "Race";
        public string _age = "0";
        public string _gender;

        public string? Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }

        public string? Race
        {
            get => _race;
            set => SetProperty(ref _race, value);
        }
        public string? Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}
