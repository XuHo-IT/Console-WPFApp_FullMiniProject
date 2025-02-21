using FPT.BOs;
using FPTBussiness.BOs;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.DAO
{
    public class UserDAO
    {
        private static UserDAO? instance = null;
        private static readonly object instanceLock = new object();
        private readonly FPTBusinessContext _context;

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

        public UserDAO()
        {
            _context = new FPTBusinessContext();
        }
        public List<UserAccount> GetUsers()
        {
            return _context.UserAccounts.ToList();

        }
        public UserAccount GetUseryId(int userId)
        {

            return _context.UserAccounts.FirstOrDefault(user => user.AccountID == userId);
        }
        public UserAccount GetUserByEmailAndPassword(string email, string password)
        {

            return _context.UserAccounts.FirstOrDefault(u => u.UserName == email && u.Password == password);
        }

    }
}
