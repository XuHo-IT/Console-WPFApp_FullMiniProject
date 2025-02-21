using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTBussiness.BOs
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "ProjectName is required.")]
        [StringLength(50, ErrorMessage = "ProjectName cannot exceed 50 characters.")]
        public string NameProject { get; set; }
    }
}
