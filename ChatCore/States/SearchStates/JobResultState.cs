using ChatCore.Models;
using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCore.States.SearchStates
{
    class JobResultState : BaseSearchState
    {
        public override void HandleMsg(TalkSession session, Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Content))
            {
                if (msg.Content == "1")
                {
                    Search.PageIndex++;
                    session.State = new JobResultState() { Search = Search };
                }
                else if (msg.Content == "2")
                {
                    Search.PageIndex--;
                    session.State = new JobResultState() { Search = Search };
                }
                else
                {
                    if (msg.Content == "Search")
                        session.State = new SearchStartStates();
                    else if (msg.Content == "profile")
                        session.State = new UserProfileStates.UserProfileState();
                }
            }
        }

        public override string Content
        {
            get
            {
                IJobRepositary repositary = new JobRepositaryByAPI();
                var results = repositary.Search(new JobSearchQuery()
                {
                    KeyWord = Search.Keyword,
                    Location = Search.Location,
                    PageSize = 3,
                    StartIndex = Search.PageIndex * 3
                });
                var sb = new StringBuilder();
                foreach (var t in results)
                {
                    sb.AppendFormat("Title:{0}\nDID:{1}", t.JobTitle, t.DID);
                }
                sb.AppendLine("输入1到下一页");
                return sb.ToString();
            }
        }

        public override ReplyMessage Message
        {
            get
            {
                IJobRepositary repositary = new JobRepositaryByAPI();
                var results = repositary.Search(new JobSearchQuery()
                {
                    KeyWord = Search.Keyword,
                    Location = Search.Location,
                    PageSize = 3,
                    StartIndex = Search.PageIndex * 3
                });

                if (results.Count > 0)
                {
                    return new ReplyJobResultMessage()
                    {
                        CreateDT = DateTime.Now,
                        From = _TalkSession.To,
                        To = _TalkSession.From,
                        Results = results.Select(t => new JobResult()
                        {
                            DID = t.DID,
                            CompanyName = t.Company,
                            Description = t.Detail,
                            Title = t.JobTitle,
                            JobDetailsURL = t.JobDetailsURL,
                            CompanyImageURL = t.CompanyImageURL
                        }).ToList()
                    };
                }
                else
                {
                    return new ReplyTextMessage()
                    {
                        CreateDT = DateTime.Now,
                        From = _TalkSession.To,
                        To = _TalkSession.From,
                        Content = "啊欧，没有找到工作。。。。。重新开始搜索吧~~"
                    };
                }
            }
        }
    }
}
