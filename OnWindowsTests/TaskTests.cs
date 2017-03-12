using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnowSharp;
using SnowSharp.GameObjects;
using System;


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
            Core.Objects.Add(new Task(() => flag = true, 10));
            Core.Objects.Add(new Task(() => win.Exit(), 20));
            win.Run();

            Assert.IsTrue(flag);
        }
    }
}

