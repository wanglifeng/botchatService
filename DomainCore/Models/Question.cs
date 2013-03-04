using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomainCore.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100),Required]
        public String Content { get; set; }
        [MaxLength(100), Required]
        public String Answer { get; set; }
    }
}
