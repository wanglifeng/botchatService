using ChatCore;
using ChatCore.States;
using ChatCore.States.UserProfileStates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatCoreTest
{
    [TestClass]
    public class UserProfileSessionTest
    {
        [TestMethod]
        public void InputName()
        {
            TalkSession session = new TalkSession(Guid.NewGuid().ToString());
            Assert.IsInstanceOfType(session.State, typeof(NewState));

            Message msg = new Message();
            msg.Content = "Profile";
            session.Request(msg);
            Assert.IsInstanceOfType(session.State, typeof(UserProfileState));

            msg.Content = "1";
            session.Request(msg);
            Assert.IsInstanceOfType(session.State, typeof(UserProfileWaitNameState));

            msg.Content = "哈";
            session.Request(msg);
            Assert.IsInstanceOfType(session.State, typeof(UserProfileWaitNameState));

            msg.Content = "王利峰";
            session.Request(msg);
            Assert.IsInstanceOfType(session.State, typeof(UserProfileState));
        }
    }
}
