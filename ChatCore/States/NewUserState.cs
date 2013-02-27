using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States
{
    public class NewUserState : NewState
    {
        public override string Content
        {
            get
            {
                return "欢迎您" + base.Content;
            }
        }
    }
}
