using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class EmployeeBranch
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [ForeignKey("Employee")]
        public int? CutomerId { get; set; }

        public virtual Employee Employee { get; set; }

        [ForeignKey("Branch")]
        public int? BranchId { get; set; }

        public virtual Branch Branch { get; set; }
    }
}
