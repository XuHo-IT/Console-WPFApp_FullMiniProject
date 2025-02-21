using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Bill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }

        [ForeignKey("ShopItem")]
        public int ShopItemId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateBuy { get; set; }

    }
}
