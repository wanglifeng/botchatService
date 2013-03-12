using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore.Models;

namespace ChatCoreConsole
{
    public class UserRepositaryByStaticClass : IUserRepositary
    {
        private static List<User> Users = new List<User>();

        public User GetById(int id)
        {
            return Users.SingleOrDefault(t => t.Id == id);
        }

        public User GetByUserName(string uesrname)
        {
            return Users.SingleOrDefault(t => t.UserName == uesrname);
        }

        public void Save(User user)
        {
            Users.Add(user);
        }

        public List<User> List()
        {
            return Users;
        }
    }
}
