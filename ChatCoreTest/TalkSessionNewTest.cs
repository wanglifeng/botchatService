using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ChatCore;
using ChatCore.States;
using ChatCore.States.SearchStates;
using ChatCore.States.UserProfileStates;

namespace ChatCoreTest
{
    [TestClass]
    public class TalkSessionNewTest
    {
        [TestMethod]
        public void NewSession()
        {
            TalkSession session = new TalkSession("wanglifeng");
            Assert.IsInstanceOfType(session.State, typeof(NewState));

            Message msg = new Message();
            msg.Content = "Search";
            session.Request(msg);
            Assert.IsInstanceOfType(session.State, typeof(SearchStartStates));

            msg.Content = "Profile";
            session.Request(msg);
            Assert.IsInstanceOfType(session.State, typeof(WaitLocationState));
        }
    }
}
