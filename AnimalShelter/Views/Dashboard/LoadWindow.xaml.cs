using AnimalShelter.Controllers;
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
    /// Lógica de interacción para LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : UserControl
    {
        ItemController ic = new ItemController();
        
        public LoadWindow()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            bool load = await ic.LoadItems();

            if (load)
            {
                var parentGrid = this.Parent as Grid;
                if (parentGrid != null)
                {
                    var parentWindow = Window.GetWindow(parentGrid);
                    if (parentWindow != null)
                    {
                        parentGrid.Children.Add(new Inventary(ic.Items));
                        parentGrid.Children.Remove(this);
                    }
                }
            }

        }
    }
}
