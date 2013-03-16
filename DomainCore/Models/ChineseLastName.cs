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

        public static explicit operator ChineseLastName(Me.WLF.Model.ChineseLastName name)
        {
            return new ChineseLastName()
            {
                Id = name.Id,
                LastName = name.LastName
            };
        }

        public static explicit operator Me.WLF.Model.ChineseLastName(ChineseLastName name)
        {
            return new Me.WLF.Model.ChineseLastName()
            {
                Id = name.Id,
                LastName = name.LastName
            };
        }
    }
}
