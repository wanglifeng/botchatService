using ChatCore.Models;
using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatCore.Patterns;
using Me.WLF.Model;

namespace ChatCore.States.SearchStates
{
    public class JobResultState : BaseSearchState
    {
        public override void HandleMsg(TalkSession session, RequestMessage message)
        {
            if (message is RequestTextMessage)
            {
                var msg = message as RequestTextMessage;
                if (!String.IsNullOrEmpty(msg.Content))
                {
                    if (PatternManager.IsGoToNextPage(msg.Content))
                    {
                        Search.PageIndex++;
                        session.State = new JobResultState() { Search = Search };
                    }
                    else if (PatternManager.IsGoToPrePage(msg.Content))
                    {
                        Search.PageIndex--;
                        session.State = new JobResultState() { Search = Search };
                    }
                    else if (PatternManager.IsSearchStartPattern(msg.Content))
                        session.State = new SearchStartStates();
                    else if (PatternManager.IsUserProfileStart(msg.Content))
                        session.State = new UserProfileStates.UserProfileState();
                    else
                        session.State = new NewState();
                }
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
                    var r = new ReplyJobResultMessage()
                    {
                        SentTime = DateTime.Now,
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

                    r.Results.Add(new JobResult()
                    {
                        Title = "输入1查看下一页，2查看上一页，点击可以查看列表",
                        JobDetailsURL = string.Format("http://mobile.careerbuilder.com.cn/seeker/search?go=1&kw={0}&loc={1}", Search.Keyword, Search.Location)
                    });

                    return r;
                }
                else
                {
                    return new ReplyTextMessage()
                    {
                        SentTime = DateTime.Now,
                        From = _TalkSession.To,
                        To = _TalkSession.From,
                        Content = "啊欧，没有找到工作。。。。。重新开始搜索吧~~"
                    };
                }
            }
        }
    }
}
