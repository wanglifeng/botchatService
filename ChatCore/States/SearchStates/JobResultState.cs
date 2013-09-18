using ChatCore.Models;
using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatCore.Patterns;
using Me.WLF.Model;
using Ninject;
using ChatCore.States.UserProfileStates;
using Me.WLF.IDAL;

namespace ChatCore.States.SearchStates
{
    public class JobResultState : BaseSearchState
    {
        private ReplyMessage _ReplyMessage = null;

        [Inject]
        public IFeedBackRepositary FeedBackRepositary { get; set; }

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
                    }
                    else if (PatternManager.IsGoToPrePage(msg.Content))
                    {
                        Search.PageIndex--;
                    }
                    else if (PatternManager.IsSearchStartPattern(msg.Content))
                        session.State = Kernel.Get<SearchStartStates>();
                    else if (PatternManager.IsUserProfileStart(msg.Content))
                        session.State = Kernel.Get<UserProfileState>();
                    else if (PatternManager.IsFeedBackPattern(msg.Content))
                    {
                        FeedBackRepositary.Save(new Me.WLF.Model.FeedBack()
                        {
                            UserName = msg.From,
                            ClientId = "wechat",
                            Content = msg.Content
                        });
                        PreMsg = Kernel.Get<IConstMessageRepositary>().GetMessage("ThanksYourFeedBack", _TalkSession.Language);

                        session.State = Kernel.Get<NewState>();
                        session.State.PreMsg = PreMsg;
                    }
                    else
                        session.State = Kernel.Get<NewState>();
                }
            }
        }

        public override ReplyMessage Message
        {
            get
            {
                if (_ReplyMessage != null)
                    return _ReplyMessage;

                IJobRepositary repositary = new JobRepositaryByAliCSS();
                var results = repositary.Search(new JobSearchQuery()
                {
                    KeyWord = Search.Keyword,
                    JobTitle = Search.JobTitle,
                    Location = Search.Location,
                    PageSize = 3,
                    StartIndex = Search.PageIndex * 3
                });

                if (results != null && results.Count > 0)
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

                    var jobresultNote = new StringBuilder();
                    jobresultNote.Append(Kernel.Get<IConstMessageRepositary>().GetMessage("Press1NextPage", _TalkSession.Language));
                    jobresultNote.Append(Kernel.Get<IConstMessageRepositary>().GetMessage("Press2PrePage", _TalkSession.Language));
                    jobresultNote.Append(Kernel.Get<IConstMessageRepositary>().GetMessage("ClickGotJobList", _TalkSession.Language));

                    r.Results.Add(new JobResult()
                    {
                        Title = jobresultNote.ToString(),
                        JobDetailsURL = string.Format("http://mobile.careerbuilder.com.cn/seeker/search?go=1&kw={0}&loc={1}", Search.Keyword, Search.Location)
                    });

                    _ReplyMessage = r;
                }
                else
                {
                    _ReplyMessage = new ReplyTextMessage()
                    {
                        SentTime = DateTime.Now,
                        From = _TalkSession.To,
                        To = _TalkSession.From,
                        Content = Kernel.Get<IConstMessageRepositary>().GetMessage("NoJobFound", _TalkSession.Language)
                    };
                }

                return _ReplyMessage;
            }
        }
    }
}
