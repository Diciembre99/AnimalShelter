using AnimalShelterWPF.Controllers;
using AnimalShelterWPF.Models;
using Microsoft.Extensions.Logging;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace AnimalShelter.Views.Home
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UserController userController = new UserController();
        public Login()
        {
            InitializeComponent();
        }


        private async void  btnLogin1_Click_1(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            
            User isAuthenticated = await userController.AuthenticateUserAsync(username, password);


            if (isAuthenticated != null)
            {
                MainWindow home = new MainWindow(isAuthenticated);
                home.Show();
                var notificationManager = new NotificationManager();

                notificationManager.Show(new NotificationContent
                {
                    Title = "Bienvenido",
                    Message = "Se ha iniciado de forma correcta",
                    Type = NotificationType.Success

                });
                Console.Write("Inicio de sesion");
                this.Close();
            }
            else
            {
                Trace.WriteLine("Credenciales erroneas Probar admin - adm1234");
                var notificationManager = new NotificationManager();

                notificationManager.Show(new NotificationContent
                {
                    Title = "Error al iniciar sesion",
                    Message = "Ha ocurrido un error al registrarse",
                    Type = NotificationType.Error
                });
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
