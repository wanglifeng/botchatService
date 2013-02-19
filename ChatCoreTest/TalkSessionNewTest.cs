﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ChatCore;
using ChatCore.States;
using ChatCore.States.SearchStates;

namespace ChatCoreTest
{
    [TestClass]
    public class TalkSessionNewTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TalkSession session = new TalkSession();
            Assert.IsInstanceOfType(session.State, typeof(NewState));

            Message msg = new Message();
            session.Request(msg);
            Assert.IsInstanceOfType(session.State, typeof(SearchStartStates));
        }
    }
}
