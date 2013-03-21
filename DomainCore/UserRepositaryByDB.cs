using DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore
{
    public class UserRepositaryByDB : IUserRepositary
    {
        public User GetById(int id)
        {
            using (ChatContext c = new ChatContext())
            {
                return c.Users.SingleOrDefault(t => t.Id == id);
            }
        }

        public void Save(Models.User user)
        {
            using (ChatContext c = new ChatContext())
            {
                User u = c.Users.SingleOrDefault(t => t.UserName == user.UserName);
                if (u == null)
                {
                    u = new User();
                    u.ClientId = user.ClientId;
                    u.Degree = user.Degree;
                    u.Location = user.Location;
                    u.Name = user.Name;
                    u.UserName = user.UserName;
                    u.Language = user.Language.ToString();
                    c.Users.Add(u);
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

        public List<Models.User> List()
        {
            using (ChatContext c = new ChatContext())
            {
                return c.Users.ToList();
            }
        }


        public User GetByUserName(string username)
        {
            using (ChatContext c = new ChatContext())
            {
                return c.Users.SingleOrDefault(t => t.UserName == username);
            }
        }
    }
}
