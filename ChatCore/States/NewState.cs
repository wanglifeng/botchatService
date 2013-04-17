using ChatCore.States.SearchStates;
using ChatCore.States.UserProfileStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCore;
using DomainCore.Models;
using ChatCore.Models;
using ChatCore.Patterns;

using Me.WLF.Model;
using Me.WLF.IDAL;
using Ninject;
namespace ChatCore.States
{
    public class NewState : BaseState
    {
        [Inject]
        public IFeedBackRepositary FeedBackRepositary { get; set; }

        public override void Handle(TalkSession session, RequestMessage msg)
        {
            if (msg is RequestTextMessage)
            {
                var m = msg as RequestTextMessage;
                if (session.User.Language == Language.None)
                    session.State = Kernel.Get<WaitLanguageState>();
                else if (PatternManager.IsSearchStartPattern(m.Content))
                    session.State = Kernel.Get<SearchStartStates>();
                else if (PatternManager.IsUserProfileStart(m.Content))
                    session.State = Kernel.Get<UserProfileState>();
                else if (PatternManager.IsNewRegisterUser(m.Content))
                    session.State = Kernel.Get<NewUserState>();
                else if (PatternManager.IsLanguage(m.Content))
                    session.State = Kernel.Get<WaitLanguageState>();
                else if (PatternManager.IsFeedBackPattern(m.Content))
                {
                    FeedBackRepositary.Save(new Me.WLF.Model.FeedBack()
                    {
                        UserName = msg.From,
                        ClientId = "wechat",
                        Content = m.Content
                    });
                    PreMsg = Kernel.Get<IConstMessageRepositary>().GetMessage("ThanksYourFeedBack", _TalkSession.Language);

                    session.State = Kernel.Get<NewState>();
                    session.State.PreMsg = PreMsg;
                }
            }
            else if (msg is RequestEventMessage)
            {
                RequestEventMessage m = msg as RequestEventMessage;
                if (m.Event == "subscribe")
                {
                    if (session.User.Language == Language.None)
                    {
                        session.State = Kernel.Get<WaitLanguageState>();
                        session.State.PreMsg = Kernel.Get<IConstMessageRepositary>().GetMessage("WelcomeNewUser", _TalkSession.Language); ;
                    }
                    else
                    {
                        session.State = Kernel.Get<NewUserState>();
                        session.State.PreMsg = Kernel.Get<IConstMessageRepositary>().GetMessage("WelcomeBack", _TalkSession.Language); ; ;
                    }
                }
                else if (m.Event == "unsubscribe")
                {
                    session.User.Status = "unsubscribe";
                    Kernel.Get<IUserRepositary>().Save(session.User);
                }
            }
        }
    }
}
