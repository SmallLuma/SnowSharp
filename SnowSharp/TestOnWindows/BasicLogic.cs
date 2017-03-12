using SnowSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnWindows;
using System;

namespace OnWindows.Tests
{
    [TestClass()]
    class BasicLogic
    {
        GameWindow win = GameWindow.PrepTestWindow();


        [TestMethod()]
        void Tasks()
        {
            Boolean flag = false;
            Core.Logics.Add(new Task(() => Core.RequestRedraw(1), 180));
            Core.Logics.Add(new Task(() => flag = true, 180));
            Core.Logics.Add(new Task(() => win.Exit(), 270));
            win.Run();

            Assert.IsTrue(flag);
        }
    }
}
