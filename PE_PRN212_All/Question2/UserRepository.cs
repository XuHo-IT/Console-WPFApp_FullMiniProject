using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class UserRepository
    {
        public List<User> GetAllUsers() => UserDAO.Instance.GetAllUsers();
     
        public void UpdateUser(User user) => UserDAO.Instance.UpdateUser(user);
    
        }
}
