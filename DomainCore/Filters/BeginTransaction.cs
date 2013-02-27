using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore.DB;

namespace DomainCore.Filters
{
    class BeginTransaction : IFilter
    {
        public bool Filters(string userId, string content, out string result)
        {

            if (content == "1" || content == "1")
            {
                User user = DataBase.Instance.Users.SingleOrDefault(t => t.ID == userId);
                if (user == null)
                {
                    user = new User() { ID = userId };
                    DataBase.Instance.Users.Add(user);
                }

                DataBase.Instance.Transaction.RemoveAll(t => t.UserId == userId);

                Transaction transaction = new Transaction() { UserId = userId };
                DataBase.Instance.Transaction.Add(transaction);
                transaction.Status = Status.New;

                result = "请输入职位关键字 Please type Keywords";

                return true;
                
            }
            result = string.Empty;
            return false;
        }
    }
}
