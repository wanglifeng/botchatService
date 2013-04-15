using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore.DB;

namespace DomainCore.Filters
{
    class ConstContentFilter : IFilter
    {

        

        public ConstContentFilter()
        {
            
        }

        public bool Filters(string userId, string content,out  string result)
        {
            User user = DataBase.Instance.Users.SingleOrDefault(t => t.ID == userId);
            if (user == null)
            {
                user = new User() { ID = userId };
                DataBase.Instance.Users.Add(user);
            }


            if (content == "Hello2BizUser")
            {
                result = "Welcome new user, type 1 for beginning new Search. 我是小C，我将为您提供最适合您的职位，输入1开始搜索吧";
            }
            else if (content == "您是谁" || content == "who are you")
            {
                result = "I'm Xiao C,我是小C，输入1开始搜索职位吧";
            }
            else
            {
                result = string.Empty;
            }
            return !String.IsNullOrEmpty(result);
        }
    }
}
