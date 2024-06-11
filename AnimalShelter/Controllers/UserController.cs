using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace AnimalShelterWPF.Controllers
{
    public class UserController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }


        public UserController()
        {
            LoadUser();
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                using (var context = new ApplicationContext())
                {
                    var user = await context.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);
                    return user;
                }
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public async void LoadUser()
        {
            try
            {
                using (var context = new ApplicationContext())
                {
                    var users = await context.Users.Include(u => u.IdCatalogeNavigation).ToListAsync();
                    Users = new ObservableCollection<User>(users);
                }
            }
            catch (Exception ex)
            {
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
