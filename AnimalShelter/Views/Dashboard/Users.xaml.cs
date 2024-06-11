using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;
using Microsoft.EntityFrameworkCore;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class Users : UserControl
    {

        private ApplicationContext _context = new ApplicationContext();
        public Users()
        {
            InitializeComponent();

        }


        private void dgUser_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {

                if (e.EditAction == DataGridEditAction.Commit)
                {
                    var user = e.Row.Item as User;
                    if (user != null)
                    {
                        var existingUser = _context.Users.Find(user.IdUser);
                        if (existingUser == null)
                        {
                            user.IdShelter=1;
                            _context.Users.Add(user);
                            var notificationManager = new NotificationManager();

                            notificationManager.Show(new NotificationContent
                            {
                                Title = "Modificacion de usuario",
                                Message = "Se modifico "+ user.Name + "correctamente",
                                Type = NotificationType.Information
                            });
                        }
                        else
                        {

                            _context.Entry(existingUser).CurrentValues.SetValues(user);
                            var notificationManager = new NotificationManager();

                            notificationManager.Show(new NotificationContent
                            {
                                Title = "Usuario agregado",
                                Message = "Se ha agregado un nuevo usuario",
                                Type = NotificationType.Success
                            });
                        }
                        _context.SaveChanges();
                    }
                }
            } catch (Exception ex) {
            }
        }
    }
}
