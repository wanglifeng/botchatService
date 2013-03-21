using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.Model;

namespace Me.WLF.IDAL
{
    public interface  IAdminRepositary
    {
        void Save(Admin admin);
        List<Admin> List();
        Admin GetById(int id);
        Admin GetByUserNameAndPassword(string username, string password);
    }
}
