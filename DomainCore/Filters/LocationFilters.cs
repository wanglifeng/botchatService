using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore.DB;

namespace DomainCore.Filters
{
    class LocationFilters : IFilter
    {
        public bool Filters(string userId, string content, out  string result)
        {
            User user = DataBase.Instance.Users.SingleOrDefault(t => t.ID == userId);
            if (user != null)
            {
                if (content == "上海" || content == "shanghai")
                {
                    Transaction transaction = DataBase.Instance.Transaction.SingleOrDefault(t => t.UserId == userId);
                    if (transaction != null && transaction.Status == Status.KeyWordSet)
                    {
                        transaction.Location = content;
                        transaction.Status = Status.Done;
                        //result = "这里是职位结果";
                        IList<JobSearchResult> results = (new JobRepositaryByAPI()).Search(new JobSearchQuery()
                            {
                                KeyWord = transaction.KeyWord,
                                Location = transaction.Location,
                                PageSize = 3,
                                StartIndex = 1
                            });
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < results.Count; i++)
                        {
                            sb.AppendFormat("{0}:{1} http://www.careerbuilder.com.cn/jobs/{2} ", i + 1, results[i].JobTitle,results[i].DID);
                        }
                        result = sb.ToString();
                        return true;
                    }
                }

            }
            result = string.Empty;
            return false;
        }
    }
}
