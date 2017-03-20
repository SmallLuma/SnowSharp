using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnWindows;
using SnowSharp;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnWindows.Tests
{
    [TestClass()]
    public class RVSharpTest
    {
        [TestMethod()]
        public void RVSharpReadTest()
        {
            var source = new LocalFileSource();
            source.SetDir("../../");
            SnowSharp.FileSystem.AddSource(source);

            var rvs = new SnowSharp.Utils.RVSharp("RVSharpTest.rvs");
            Console.WriteLine(rvs.Get<double>("Key_1"));
            Console.WriteLine(rvs.Get<int>("Key_2"));
            Console.WriteLine(rvs.Get<int>("Key_3"));
            Console.WriteLine(rvs.Get<string>("Key_4"));
            Console.WriteLine(rvs.Get<int>("Key_5"));
            Console.WriteLine(rvs.Get<string>("Key_6"));
        }
    }
}