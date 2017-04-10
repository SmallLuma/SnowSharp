﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnowSharp.Util;
using SnowSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnWindows.Tests
{
    [TestClass()]
    public class CSVReaderTests
    {
        [TestMethod()]
        public void CSVReaderTest()
        {

            var source = new LocalFileSource();
            source.Dir = "../../";
            FileSystem.AddSource(source);

            CSVReader csv = new CSVReader("CSVTestFile.csv");


            while (csv.EnumLine()) { 
                while (!csv.IsLineEnd)
                {
                    Console.Write(csv.Pop<string>() + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}