using AnimalShelter.Views.Dashboard;
using AnimalShelterWPF.Controllers;
using System.Windows;
using System.Windows.Controls;

namespace AnimalShelter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new Pets());
        }

        public void LoadUserControl (UserControl userControl)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(userControl);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabControl = sender as TabControl;
            var selectedTab = tabControl.SelectedItem as TabItem;

            if (selectedTab != null)
            {
                switch (selectedTab.Tag.ToString())
                {
                    case "ItemHome":
                        RenderPage.Children.Clear();
                        RenderPage.Children.Add(new Pets());
                        txtTitle.Text="Pets";
                        break;
                    case "RecentItem":
                        RenderPage.Children.Clear();
                        RenderPage.Children.Add(new AddPet());
                        break;
                }
            }
        }
    }
}