using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomainCore.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public String Name { get; set; }

        [MaxLength(200)]
        public String TypeName { get; set; }

        [MaxLength(1000)]
        public String Description { get; set; }

        public List<StateMessage> Messages { get; set; }

        public static explicit operator State(Me.WLF.Model.State u)
        {
            return new State()
            {
                Description = u.Description,
                Id = u.Id,
                Name = u.Name,
                TypeName = u.TypeName
            };
        }

        public static explicit operator Me.WLF.Model.State(State u)
        {
            return new Me.WLF.Model.State()
            {
                Description = u.Description,
                Id = u.Id,
                Name = u.Name,
                TypeName = u.TypeName
            };
        }

    }
}
