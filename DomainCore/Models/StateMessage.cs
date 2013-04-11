using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Me.WLF.Model;

namespace DomainCore.Models
{
    public class StateMessage
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public String Content { get; set; }

        public Language Language { get; set; }
    }
}
