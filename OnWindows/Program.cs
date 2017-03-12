using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace OnWindows
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow.PrepTestWindow().Run(60, 60);
        }
    }
}
