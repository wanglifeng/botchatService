using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.Model;

namespace Me.WLF.IDAL
{
    public interface IUserRepositary
    {
        User GetById(int id);
        User GetByUserName(string uesrname);
        void Save(User user);
        List<User> List();

        void Del(int id);
    }
}
