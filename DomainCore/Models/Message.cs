using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomainCore.Models
{
    class Message
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50),Required]
        public String From { get; set; }
        [MaxLength(50), Required]
        public String To { get; set; }
        [MaxLength(500), Required]
        public String Content { get; set; }
        [Required]
        public DateTime CreateDT { get; set; }

       
    }
}
