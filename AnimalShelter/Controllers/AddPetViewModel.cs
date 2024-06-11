using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AnimalShelter.Controllers
{
    public class AddPetViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string _name;
        public string _race;
        public string _age = "0";
        public string _gender;
        public string _entryDate;
        public string _description;
        public string _size;
        public string _hair;
        public string _species;
        public string _numChip;

        public string NumChip
        {
            get => _numChip;
            set => SetProperty(ref _numChip, value);
        }

        public string Species
        {
            get => _species;
            set => SetProperty(ref _species, value);
        }
        public string? hair
        {
            get => _hair;
            set => SetProperty(ref _hair, value);
        }
        public string? Size
        {
            get => _size;
            set => SetProperty(ref _size, value);
        }
        public string? DateEntry
        {
            get => _entryDate;
            set => SetProperty(ref _entryDate, value);
        }
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
        public string? Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        private ObservableCollection<KeyValuePair<string, Color>>? _autoSuggestBox2Suggestions;
        private string? _autoSuggestBox2Text;
        private readonly List<KeyValuePair<string, Color>>? _originalAutoSuggestBox2Suggestions;

        public ObservableCollection<KeyValuePair<string, Color>>? AutoSuggestBox2Suggestions
        {
            get => _autoSuggestBox2Suggestions;
            set => SetProperty(ref _autoSuggestBox2Suggestions, value);
        }
        public string? AutoSuggestBox2Text
        {
            get => _autoSuggestBox2Text;
            set
            {
                if (SetProperty(ref _autoSuggestBox2Text, value) &&
                    _originalAutoSuggestBox2Suggestions != null && value != null)
                {
                    var searchResult = _originalAutoSuggestBox2Suggestions.Where(x => IsMatch(x.Key, value));
                    AutoSuggestBox2Suggestions = new ObservableCollection<KeyValuePair<string, Color>>(searchResult);
                }
            }
        }
        private ObservableCollection<string>? _autoSuggestBox1Suggestions;
        private string? _autoSuggestBox1Text;
        private readonly List<string>? _originalAutoSuggestBox1Suggestions;

        public ObservableCollection<string>? AutoSuggestBox1Suggestions
        {
            get => _autoSuggestBox1Suggestions;
            set => SetProperty(ref _autoSuggestBox1Suggestions, value);
        }

        public string? AutoSuggestBox1Text
        {
            get => _autoSuggestBox1Text;
            set
            {
                if (SetProperty(ref _autoSuggestBox1Text, value) &&
                    _originalAutoSuggestBox1Suggestions != null && value != null)
                {
                    var searchResult = _originalAutoSuggestBox1Suggestions.Where(x => IsMatch(x, value));
                    AutoSuggestBox1Suggestions = new ObservableCollection<string>(searchResult);
                }
            }
        }
  
        
        public AddPetViewModel()
        {
            _originalAutoSuggestBox1Suggestions = new List<string>()
            {
                "Rizado", "Liso", "Corto", "Largo", "Duro", "Sedoso", "Ondulado", "Rizado Africano"
            };
            _originalAutoSuggestBox2Suggestions = GetCustomColors();
        }

        private static bool IsMatch(string item, string currentText)
        {
            return item.Contains(currentText, StringComparison.OrdinalIgnoreCase);
        }

        private List<KeyValuePair<string, Color>> GetCustomColors()
        {
            // Definir tu propia lista de colores aquí
            return new List<KeyValuePair<string, Color>>
            {
                new KeyValuePair<string, Color>("Blanco", Colors.White),
                new KeyValuePair<string, Color>("Negro", Colors.Black),
                new KeyValuePair<string, Color>("Marrón", Colors.Brown),
                new KeyValuePair<string, Color>("Gris", Colors.Gray),
                new KeyValuePair<string, Color>("Rubio", Colors.Beige),
                new KeyValuePair<string, Color>("Atigrado", Colors.Sienna),
                new KeyValuePair<string, Color>("Gris azulado", Colors.SlateGray),
                new KeyValuePair<string, Color>("Naranja", Colors.Orange),
                new KeyValuePair<string, Color>("Amarillo", Colors.Yellow),
                new KeyValuePair<string, Color>("Dorado", Colors.Gold),
                new KeyValuePair<string, Color>("Plateado", Colors.Silver),
                new KeyValuePair<string, Color>("Gris oscuro", Colors.DarkGray),
                new KeyValuePair<string, Color>("Gris claro", Colors.LightGray),
                new KeyValuePair<string, Color>("Tricolor", Colors.DarkRed)
            };
        }
    }

}
