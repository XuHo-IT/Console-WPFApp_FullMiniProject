using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class ShopInformationDAO
    {
        private static ShopInformationDAO? instance = null;
        private static readonly object instanceLock = new object();
        private readonly PawnShopContext _context;

        public static ShopInformationDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ShopInformationDAO();
                    }
                    return instance;
                }
            }
        }

        public ShopInformationDAO()
        {
            _context = new PawnShopContext();
        }
        public ShopInformation GetInformation()
        {
            return _context.ShopInformation.FirstOrDefault(); 
        }

    }
}
