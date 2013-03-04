using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore.Models;

namespace DomainCore
{
    public interface IUserRepositary
    {
        User GetById(int id);
        User GetByUserName(string uesrname);
        void Save(User user);
        List<User> List();
    }
}
