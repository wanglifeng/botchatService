using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomainCore.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public String UserName { get; set; }
        [MaxLength(50), Required]
        public String ClientId { get; set; }
        [MaxLength(10)]
        public String Location { get; set; }
        [MaxLength(10)]
        public String Name { get; set; }
        [MaxLength(5)]
        public String Degree { get; set; }

    }
}
