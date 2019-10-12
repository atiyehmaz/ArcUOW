using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [StringLength(15, MinimumLength =5, ErrorMessage = "Contact number should have 5 - 15 digits")]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
