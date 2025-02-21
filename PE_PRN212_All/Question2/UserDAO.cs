using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class UserDAO
    {
        private static UserDAO? instance = null;
        private static readonly object instanceLock = new object();
        private PePrn24fallB1Context _context;

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }


        private UserDAO() { }


        public List<User> GetAllUsers()
        {
            using (var _context = new PePrn24fallB1Context())
            {
                return _context.Users.ToList();
            }
        }
        public void UpdateUser(User user)
        {
            using (var context = new PePrn24fallB1Context())
            {
                context.Users.Update(user);
                context.SaveChanges();
            }
        }
    }
}
