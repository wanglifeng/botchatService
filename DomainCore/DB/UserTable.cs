using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCore.DB
{
    class DataBase
    {
        public List<User> Users { get; set; }
        public List<Transaction> Transaction { get; set; }

        private DataBase()
        {
            Users = new List<User>();
            Transaction = new List<Transaction>();
        }

        private static DataBase _DataBase;

        public static DataBase Instance
        {
            get
            {
                if (_DataBase == null)
                    _DataBase = new DataBase();

                return _DataBase;
            }
        }
    }
}
