using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BotChatServiceWeb.Models
{
    public class UserLoginModel
    {
        [Required]
        public String UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}