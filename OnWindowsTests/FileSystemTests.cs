using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnWindows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SnowSharp;
namespace OnWindows.Tests
{
    [TestClass()]
    public class FileSystemTests
    {
        [TestMethod()]
        public void TestLoadLocalFile()
        {
            var src = new LocalFileSource();
            SnowSharp.FileSystem.AddSource(src);

            src = new LocalFileSource();
            src.SetDir("../../../OnWindows");
            SnowSharp.FileSystem.AddSource(src);

            var s = SnowSharp.FileSystem.OpenFile("LocalFileSource.cs");
            Console.WriteLine(new StreamReader(s).ReadToEnd());
        }
    }
}