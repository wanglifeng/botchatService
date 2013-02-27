using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore.DB;

namespace DomainCore.Filters
{
    class KeyWordFilter : IFilter
    {
        public bool Filters(string userId, string content, out  string result)
        {
            User user = DataBase.Instance.Users.SingleOrDefault(t => t.ID == userId);

            if (user != null)
            {
                Transaction transaction = DataBase.Instance.Transaction.SingleOrDefault(t => t.UserId == userId);
                if (transaction != null && transaction.Status== Status.New)
                {
                    transaction.KeyWord = content;
                    transaction.Status = Status.KeyWordSet;
                    result = "请输入工作地点 please type location";
                    return true;
                }

            }
            result = string.Empty;
            return false;
        }
    }
}
