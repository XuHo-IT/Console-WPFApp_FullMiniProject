using FPT.DAO;
using FPTBussiness.BOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.Repository
{
    public class UserRepository
    {
        public List<UserAccount> GetUsers() => UserDAO.Instance.GetUsers();
      
        public UserAccount GetUseryId(int userId) => UserDAO.Instance.GetUseryId(userId);
      
        public UserAccount GetUserByEmailAndPassword(string email, string password)=>UserDAO.Instance.GetUserByEmailAndPassword(email, password);
      
    }
}
