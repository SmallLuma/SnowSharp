using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnowSharp;
using SnowSharp.Util;
using System;

namespace OnWindows.Tests
{
    [TestClass()]
    public class RVSharpTest
    {
        [TestMethod()]
        public void RVSharpReadTest()
        {
            var source = new LocalFileSource();
            source.Dir = "../../";
            FileSystem.AddSource(source);

            var rvs = new RVSharp("RVSharpTest.rvs");
            Console.WriteLine(rvs.Get<double>("Key_1"));
            Console.WriteLine(rvs.Get<int>("Key_2"));
            Console.WriteLine(rvs.Get<int>("Key_3"));
            Console.WriteLine(rvs.Get<string>("Key_4"));
            Console.WriteLine(rvs.Get<int>("Key_5"));
            Console.WriteLine(rvs.Get<string>("Key_6"));
        }
    }
}