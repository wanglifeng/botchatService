using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomainCore.Models
{
    public class ConstMessage
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public String Format { get; set; }

        public String Content { get; set; }
        
        [MaxLength(50)]
        public String Language { get; set; }

    }
}
