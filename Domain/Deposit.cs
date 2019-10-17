using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Deposit
    {
        [Key]
        [Required]
        public int Id{ get; set; }

        [Range(1000, 10000000)]
        public int Balance { get; set; }

        [Range(5, 10)]
        [Required]
        public int AccountNumber { get; set; }

        public DateTime? RegistrationDate { get; set; }

        [ForeignKey("Customer")]
        public int? CutomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [ForeignKey("Branch")]
        public int? BranchId { get; set; }

        public virtual Branch Branch{ get; set; }


    }
}
