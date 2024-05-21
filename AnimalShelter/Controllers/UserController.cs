using AnimalShelter.Controllers.Data;
using AnimalShelterWPF.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
                    OnPropertyChanged("Users");
                }
            }
        }
        public UserController()
        {
        }

        
        public void AddUser(User user)
        {
            Users.Add(user);
        }

    
        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }
        public bool AuthenticateUser(string username, string password)
        {
            bool IsValidated = true;
            try
            {
                
                using (var context = new ApplicationContext())
                {
                    var user = context.Users.Single(u => u.Username == username && u.Password == password);
                    return user != null;
                }
            }catch(InvalidOperationException ie)
            {
                return false;
            }
        }

        
        public void UpdateUser(User user)
        {
            var existingUser = Users.FirstOrDefault(u => u.IdUser == user.IdUser);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Dni = user.Dni;
                existingUser.Telephone = user.Telephone;
                existingUser.IdShelter = user.IdShelter;
                existingUser.IdCataloge = user.IdCataloge;
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Adoption = user.Adoption;
                existingUser.IdCatalogeNavigation = user.IdCatalogeNavigation;
                existingUser.IdShelterNavigation = user.IdShelterNavigation;
                existingUser.Permissions = user.Permissions;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
