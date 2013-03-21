using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomainCore.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        [Required]
        public String UserName { get; set; }
        [MaxLength(10)]
        [Required]
        public String PassWord { get; set; }

        public static explicit operator Admin(Me.WLF.Model.Admin u)
        {
            return new Admin()
            {
                PassWord = u.Password,
                Id = u.Id,
                UserName = u.UserName
            };
        }

        public static explicit operator Me.WLF.Model.Admin(Admin u)
        {
            return new Me.WLF.Model.Admin()
            {
                 Password = u.PassWord,
                Id = u.Id,
                UserName = u.UserName
            };
        }
    }
}
