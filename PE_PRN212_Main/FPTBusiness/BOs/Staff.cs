using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTBussiness.BOs
{
    public class Staff
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }

        [Required(ErrorMessage = "Firstname is required.")]
        [StringLength(50, ErrorMessage = "Firstname cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Latsname is required.")]
        [StringLength(100, ErrorMessage = "Lastname cannot exceed 100 characters.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
    

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string AddressStaff { get; set; }


        [ForeignKey("USerAccount")]
        public int AccountID { get; set; }

    }
}
