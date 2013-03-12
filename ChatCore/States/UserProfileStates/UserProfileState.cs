using DomainCore;
using DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatCore.Models;

namespace ChatCore.States.UserProfileStates
{
    public class UserProfileState : BaseState
    {
        private String _Content = string.Empty;

        public override void Handle(TalkSession session, Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Content))
            {
                if (msg.Content == "1")
                {
                    session.State = new UserProfileWaitNameState();
                }
                else
                {
                    IQuestionRepositary repo = new QuestionRepostaryByDB();
                    Question q = repo.GetByQuestion(msg.Content);
                    if (q != null)
                        _Content = q.Answer;
                }
            }
        }



        public override string Content
        {
            get
            {
                if (String.IsNullOrEmpty(_Content))
                    return "啊欧，开始填写您的详细资料吧？输入1就可以输入姓名啦";
                else
                    return _Content;
            }
        }

        public override ReplyMessage Message
        {
            get
            {
                return new ReplyTextMessage()
                {
                    Content = "开始填写您的详细资料吧？输入1就可以输入姓名啦",
                    CreateDT = DateTime.Now,
                    From = _TalkSession.To,
                    To = _TalkSession.From
                };
            }
        }
    }
}
