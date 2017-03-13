using System;
using System.IO;
using OpenTK;
using SnowSharp;
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
            catch (Exception e)
            {
                return null;
            }
        }
        

        /// <summary>
        /// 设置起始目录
        /// </summary>
        /// <param name="path">起始目录</param>
        public void SetDir(string path)
        {
            dir = path + '/';
        }

        string dir;
    }
}
