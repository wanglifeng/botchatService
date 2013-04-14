using ChatCore.Models;
using ChatCore.States.SearchStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatCore.Patterns;

using Me.WLF.Model;
using Ninject;
using System.Configuration;
using Me.WLF.IDAL;

namespace ChatCore.States
{
    public abstract class BaseState
    {
        public String PreMsg { get; set; }

        public TalkSession _TalkSession { get; set; }

        [Inject]
        public IStateMessageRepositary StateMessageRepositary { get; set; }

        protected IKernel Kernel
        {
            get
            {
                return KernelManager.Kernel;
            }
        }

        [Inject]
        public IPatternManager PatternManager { get; set; }

        public void Handle(Message msg) { }

        public void Handle(TalkSession session, RequestMessage msg, string str)
        {
            _TalkSession = session;
            _TalkSession.LastMessage = msg;
            //if (msg is RequestTextMessage && session.Language == Language.None && !(session.State is WaitLanguageState))
            //{
            //    session.State = Kernel.Get<WaitLanguageState>();
            //}
            //else
            //{
            //    Handle(_TalkSession, msg);
            //}
            Handle(_TalkSession, msg);
            this._TalkSession = _TalkSession;
            //session.State._TalkSession = session;
        }

        public abstract void Handle(TalkSession session, RequestMessage msg);

        public virtual ReplyMessage Message
        {
            get
            {
                Random r = new Random(DateTime.Now.Millisecond);
                List<StateMessage> msgs = StateMessageRepositary.Messages(this, _TalkSession.Language);
                return new ReplyTextMessage()
                {
                    From = _TalkSession.To,
                    To = _TalkSession.From,
                    SentTime = DateTime.Now,
                    Content = msgs[r.Next(0, msgs.Count)].Content
                };
            }
        }
    }
}
