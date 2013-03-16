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

        public static explicit operator User(Me.WLF.Model.User u)
        {
            return new User()
            {
                Name = u.Name,
                Location = u.Location,
                ClientId = u.ClientId,
                Degree = u.Degree,
                Id = u.Id,
                UserName = u.UserName
            };
        }

        public static explicit operator Me.WLF.Model.User(User u)
        {
            return new Me.WLF.Model.User()
            {
                Name = u.Name,
                Location = u.Location,
                ClientId = u.ClientId,
                Degree = u.Degree,
                Id = u.Id,
                UserName = u.UserName
            };
        }
    }
}
