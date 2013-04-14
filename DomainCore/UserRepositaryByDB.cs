using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.IDAL;
using Me.WLF.Model;

namespace DomainCore
{
    public class UserRepositaryByDB : IUserRepositary
    {
        private object _LockObj = new object();

        public User GetById(int id)
        {
            using (ChatContext c = new ChatContext())
            {
                var u = c.Users.SingleOrDefault(t => t.Id == id);
                if (u != null)
                {
                    return (Me.WLF.Model.User)u;
                }
                return null;
            }
        }

        public void Save(User user)
        {
            using (ChatContext c = new ChatContext())
            {
                var u = c.Users.SingleOrDefault(t => t.UserName == user.UserName);
                if (u == null)
                {
                    lock (_LockObj)
                    {
                        u = c.Users.SingleOrDefault(t => t.UserName == user.UserName);
                        if (u == null)
                        {
                            c.Users.Add((Models.User)user);
                        }
                    }
                }
                else
                {
                    u.Degree = user.Degree;
                    u.Location = user.Location;
                    u.Name = user.Name;
                    u.Language = user.Language.ToString();
                }
                c.SaveChanges();
            }
        }

        public List<User> List()
        {
            using (ChatContext c = new ChatContext())
            {
                var u = new List<User>();
                c.Users.ToList().ForEach(t =>
                    {
                        u.Add((User)t);
                    });
                return u;
            }
        }


        public User GetByUserName(string username)
        {
            using (ChatContext c = new ChatContext())
            {
                var u = c.Users.SingleOrDefault(t => t.UserName == username);
                if (u != null)
                    return (Me.WLF.Model.User)u;
                else
                    return null;
            }
        }


        public void Del(int id)
        {
            using (ChatContext c = new ChatContext())
            {
                var u = c.Users.SingleOrDefault(t => t.Id == id);
                if (u != null)
                    c.Users.Remove(u);

                c.SaveChanges();
            }
        }
    }
}
