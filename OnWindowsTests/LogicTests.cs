using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OnWindows;
using SnowSharp;


namespace OnWindows.Tests
{
    [TestClass()]
    public class TaskTests
    {
        GameWindow win = GameWindow.PrepTestWindow();

        [TestMethod()]
        public void Tasks()
        {
            Boolean flag = false;
            Core.Logics.Add(new Task(() => Core.RequestRedraw(1), 20));
            Core.Logics.Add(new Task(() => flag = true, 40));
            Core.Logics.Add(new Task(() => win.Exit(), 60));
            win.Run();

            Assert.IsTrue(flag);
        }
    }
}

