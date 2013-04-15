using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;
using Me.WLF.IDAL;

namespace Me.WLF.DALByStatic
{
    public class UserRepositaryDALByStatic : IUserRepositary
    {
        private static List<User> Users = new List<User>();

        public User GetById(int id)
        {
            return Users.SingleOrDefault(t => t.Id == id);
        }

        public User GetByUserName(string username)
        {
            return Users.SingleOrDefault(t => t.UserName == username);
        }

        public void Save(User user)
        {
            Console.WriteLine("Saving User");
            if (Users.Exists(u => u.UserName == user.UserName))
            {
                Users.RemoveAll(u => u.UserName == user.UserName);
            }
            Users.Add(user);
            Console.WriteLine("Saved User");
        }

        public List<User> List()
        {
            return Users;
        }


        public void Del(int id)
        {
            Users.RemoveAll(t => t.Id == id);
        }
    }
}
