using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.IDAL;
using Me.WLF.Model;

namespace DomainCore
{
    public class AdminRepositaryByDB : IAdminRepositary
    {
        public void Save(Admin admin)
        {
            using (ChatContext context = new ChatContext())
            {
                var a = context.Admins.SingleOrDefault(t => t.Id == admin.Id);
                if (a == null)
                {
                    context.Admins.Add(new DomainCore.Models.Admin()
                    {
                        PassWord = admin.Password,
                        UserName = admin.UserName
                    });
                }
                else
                {
                    a.UserName = admin.UserName;
                    a.PassWord = admin.Password;
                }
                context.SaveChanges();
            }
        }

        public List<Admin> List()
        {
            using (ChatContext context = new ChatContext())
            {
                return context.Admins.Select(t => (Admin)t).ToList();
            }
        }

        public Admin GetById(int id)
        {
            using (ChatContext context = new ChatContext())
            {
                var a = context.Admins.SingleOrDefault(t => t.Id == id);
                if (a != null)
                    return (Admin)a;
            }
            return null;
        }

        public Admin GetByUserNameAndPassword(string username, string password)
        {
            using (ChatContext context = new ChatContext())
            {
                var a = context.Admins.SingleOrDefault(t => t.UserName == username && t.PassWord == password);
                if (a != null)
                    return (Admin)a;
            }
            return null;
        }
    }
}
