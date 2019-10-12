using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Branch
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [Range(0,10)]
        [Required]
        public int Type { get; set; }
    }
    //public enum Type
    //{
    //    National=0,
    //    PrivateBank=1,
    //    DevelopmentBank=2,
    //    CentralBank=3
    //}


}
