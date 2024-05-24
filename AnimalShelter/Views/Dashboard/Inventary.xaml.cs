using AnimalShelterWPF.ViewModels;
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
    /// Lógica de interacción para Inventary.xaml
    /// </summary>
    public partial class Inventary : UserControl
    {
        private ItemController items = new ItemController();
        public Inventary()
        {
            InitializeComponent();
            DataContext= items;
            items.LoadItems();

        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            gridItem.Children.Add(new AddItem());
           
        }
    }
}
