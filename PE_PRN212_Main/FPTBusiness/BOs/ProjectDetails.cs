using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTBussiness.BOs
{
    public class ProjectDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectDetailID { get; set; }

        [ForeignKey("Projects")]
        public int ProjectID { get; set; }

        [ForeignKey("Staff")]
        public int StaffID { get; set; }

        [Required(ErrorMessage = "NumberOfHours")]
        [Range(0, int.MaxValue, ErrorMessage = "NumberOfHours cannot be negative.")]
        public int NumberOfHours { get; set; }

        [Required(ErrorMessage = "RoleStaff is required.")]
        public string RoleStaff { get; set; }


 


    }
}
