using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTBussiness.BOs
{
    public class UserAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }

        [Required(ErrorMessage = "UserName  is required.")]
        [StringLength(50, ErrorMessage = "UserName  cannot exceed 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password  is required.")]
        [StringLength(100, ErrorMessage = "Password  cannot exceed 100 characters.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "User role is required.")]
        [Range(1, 5, ErrorMessage = "User role must be between 1 and 5.")]
        public int Role { get; set; }
    }
}
