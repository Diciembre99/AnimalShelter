using AnimalShelter.Views.Dashboard;
using AnimalShelter.Views.Home;
using AnimalShelterWPF.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnimalShelter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User u;
        public MainWindow(User user)
        {
            InitializeComponent();
            u = user;
            if (user.IdCataloge==2)
            {
                tabUsers.Visibility = Visibility.Collapsed;
            }

        }
        private Point puntoDeInicio;
        private void HeadWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Guarda el punto de inicio del arrastre
            puntoDeInicio = e.GetPosition(null);
        }

        private void HeadWindow_MouseMove(object sender, MouseEventArgs e)
        {
            // Solo realiza el arrastre si el botón izquierdo del mouse está presionado
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point puntoActual = e.GetPosition(null);

                // Verifica si el mouse se ha movido lo suficiente para considerarlo un arrastre
                if (Math.Abs(puntoActual.X - puntoDeInicio.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(puntoActual.Y - puntoDeInicio.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    // Inicia el arrastre
                    DragMove();
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(new Notificaciones());
        }

        public void LoadUserControl (UserControl userControl)
        {
            RenderPage.Children.Clear();
            RenderPage.Children.Add(userControl);
        }

        private async void  TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabControl = sender as TabControl;
            var selectedTab = tabControl.SelectedItem as TabItem;

            if (selectedTab != null)
            {
                switch (selectedTab.Tag.ToString())
                {
                    case "ItemHome":
                        RenderPage.Children.Clear();
                        RenderPage.Children.Add(new Notificaciones());
                        txtTitle.Text="Home";
                        break;

                    case "RecentItem":
                        RenderPage.Children.Clear();
                        RenderPage.Children.Add(new Pets());
                        txtTitle.Text="Pets";
                        break;
                    case "InventaryItem":
                        RenderPage.Children.Clear();
                        RenderPage.Children.Add(new LoadWindow());
                        txtTitle.Text="Inventary";
                        break;
                    case "AppointmentsItem":
                        RenderPage.Children.Clear();
                        RenderPage.Children.Add(new Appointments());
                        txtTitle.Text="Appointment";
                        break;
                    case "Donation":
                        RenderPage.Children.Clear();
                        RenderPage.Children.Add(new Views.Dashboard.Donation(u));
                        txtTitle.Text="Donations";
                        break;
                    case "Users":
                        RenderPage.Children.Clear();
                        RenderPage.Children.Add(new Users());
                        txtTitle.Text="Users";
                        break;
                    case "LogOut":
                        Login login = new Login();
                        login.Show();
                        this.Close();
                        break;
                }
            }
        }
    }
}