using AnimalShelterWPF.Controllers;
using Microsoft.Extensions.Logging;
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
        public Login()
        {
            InitializeComponent();
        }


        private void btnLogin1_Click_1(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            UserController userController = new UserController();
            bool isAuthenticated = userController.AuthenticateUser(username, password);


            if (isAuthenticated)
            {
                MainWindow home = new MainWindow();
                home.Show();
                MessageBox.Show("¡Inicio de sesión exitoso!");
                Console.Write("Inicio de sesion");
            }
            else
            {
                Trace.WriteLine("Credenciales erroneas Probar admin - adm1234");
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }

        }
    }
}
