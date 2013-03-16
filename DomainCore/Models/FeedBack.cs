using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomainCore.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public String UserName { get; set; }
        [MaxLength(50)]
        public String ClientId { get; set; }
        public String Content { get; set; }

        public static explicit operator FeedBack(Me.WLF.Model.FeedBack u)
        {
            return new FeedBack()
            {
                Content = u.Content,
                Id = u.Id,
                ClientId = u.ClientId,
                UserName = u.UserName
            };
        }

        public static explicit operator Me.WLF.Model.FeedBack(FeedBack u)
        {
            return new Me.WLF.Model.FeedBack()
            {
                Content = u.Content,
                Id = u.Id,
                ClientId = u.ClientId,
                UserName = u.UserName
            };
        }
    }
}
