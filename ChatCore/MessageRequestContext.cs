using ChatCore.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Me.WLF.Model;
using ChatCore.States;

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
                if (_Session == null)
                {
                    _Session = TalkSessionRepositry.Get(MessageRequest.From);

                    if (_Session == null || _Session.LastActivityDT.AddMinutes(20) < DateTime.Now)
                    {
                        if (_Session != null)
                        {
                            Console.WriteLine("Remove Session");
                            TalkSessionRepositry.Remove(MessageRequest.From);
                        }
                        else
                        {
                            Console.WriteLine("Session Is NULL");
                        }
                        Console.WriteLine("Create a new Session");

                        _Session = KernelManager.Kernel.Get<TalkSession>();
                        _Session.From = MessageRequest.From;
                        _Session.To = MessageRequest.To;
                        _Session.ClientId = MessageRequest.ClientId;
                        _Session.State = KernelManager.Kernel.Get<NewState>();
                        _Session.State._TalkSession = _Session;
                    }

                    _Session.LastActivityDT = DateTime.Now;
                    TalkSessionRepositry.Save(_Session);
                }
                return _Session;
            }
        }


    }
}
