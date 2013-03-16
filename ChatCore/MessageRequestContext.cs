using ChatCore.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.Model;

namespace ChatCore
{
    public class MessageRequestContext
    {
        private TalkSession _Session { get; set; }

        [Inject]
        public ITalkSessionRepositry TalkSessionRepositry { get; set; }

        public RequestMessage MessageRequest { get; set; }
        public TalkSession Session
        {
            get
            {
                if (TalkSessionRepositry.Get(MessageRequest.From) != null)
                {
                    _Session = TalkSessionRepositry.Get(MessageRequest.From);
                }
                else
                {
                    _Session = new TalkSession(MessageRequest.From, MessageRequest.To);
                    //_Session.State = new States.NewState();
                    TalkSessionRepositry.Save(_Session);
                }
                return _Session;
            }
        }


    }
}
