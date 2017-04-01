using SnowSharp;
using System;
using System.IO;

namespace OnWindows
{
    public class LocalFileSource:FileSystem.ISource
    {
        public Stream OpenFile(string path)
        {
            try
            {
                return File.OpenRead(dir + path);
            }
            catch (Exception)
            {
                return null;
            }
        }
        

        /// <summary>
        /// 设置起始目录
        /// </summary>
        /// <param name="path">起始目录</param>
        public string Dir
        {
            get => dir;
            set => dir = value;
        }

        string dir;
    }
}
