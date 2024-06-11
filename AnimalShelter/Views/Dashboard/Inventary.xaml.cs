using AnimalShelter.Controllers;
using AnimalShelterWPF.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace AnimalShelter.Views.Dashboard
{
    /// <summary>
    /// Lógica de interacción para Inventary.xaml
    /// </summary>
    public partial class Inventary : UserControl
    {
        private bool _isLoaded;
        private ItemController items = new ItemController();
        public Inventary(ObservableCollection<Item> i)
        {
            InitializeComponent();
            DataContext= items;
            items.Items=i;

        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            gridItem.Children.Add(new AddItem());
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (_isLoaded && textBox != null && textBox.Name != "txtSearch")
            {
                items.IsSnackbarActive = true;
                
            }
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            _isLoaded = true;
        }
    }
}
