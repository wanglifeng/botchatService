using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotChatServiceWeb.Models
{
    public class StateMessageAddModel
    {
        public int StateId { get; set; }
        public string Content { get; set; }
        public string Language { get; set; }
    }
}