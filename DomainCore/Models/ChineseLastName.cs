using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomainCore.Models
{
    public class ChineseLastName
    {
        public int Id { get; set; }
        [MaxLength(5), Required]
        public String LastName { get; set; }
    }
}
