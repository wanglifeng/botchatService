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

namespace ChatCore.States
{
    public abstract class BaseState
    {
        public String PreMsg { get; set; }

        protected TalkSession _TalkSession { get; set; }

        private IPatternManager _PatternManager;

        protected IKernel Kernel
        {
            get
            {
                return KernelManager.Kernel;
            }
        }

        [Inject]
        protected IPatternManager PatternManager
        {
            get
            {
                if (_PatternManager == null)
                {
                    var patternManagerClassName = System.Configuration.ConfigurationManager.AppSettings["IPatternManage"];
                    _PatternManager = Activator.CreateInstance(Type.GetType(patternManagerClassName)) as IPatternManager;
                }
                return _PatternManager;
            }
        }

        public void Handle(Message msg) { }

        public void Handle(TalkSession session, RequestMessage msg, string str)
        {
            _TalkSession = session;
            session.LastMessage = msg;
            if (session.Language == Language.None && !(session.State is WaitLanguageState))
            {
                session.State = Kernel.Get<WaitLanguageState>();
            }
            else
            {
                Handle(session, msg);
            }

            session.State._TalkSession = session;
        }

        public abstract void Handle(TalkSession session, RequestMessage msg);

        public abstract ReplyMessage Message { get; }
    }
}
