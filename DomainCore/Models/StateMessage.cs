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

        public String Language { get; set; }

        public State State { get; set; }

        public static explicit operator StateMessage(Me.WLF.Model.StateMessage u)
        {
            return new StateMessage()
            {
                Id = u.Id,
                Content = u.Content,
                Language = u.Language.ToString()
            };
        }

        public static explicit operator Me.WLF.Model.StateMessage(StateMessage u)
        {
            return new Me.WLF.Model.StateMessage()
            {
                Id = u.Id,
                Content = u.Content,
                Language = (Me.WLF.Model.Language)Enum.Parse(typeof(Me.WLF.Model.Language),u.Language)
            };
        }
    }
}
