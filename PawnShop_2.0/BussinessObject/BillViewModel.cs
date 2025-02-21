using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class BillViewModel
    {
        public int BillId { get; set; }
        public int ShopItemId { get; set; }
        public int UserId { get; set; }
        public DateTime DateBuy { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemDescription { get; set; }
    }

}
