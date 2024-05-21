using AnimalShelter.Controllers.Data;

namespace AnimalShelter.Modules
{
    internal class UserModules
    {
        public bool AuthenticateUser(string username, string password)
        {
            using (var context = new ApplicationContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                return user != null;
            }
        }
    }
}
