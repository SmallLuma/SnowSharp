using System.IO;
using System.Collections.Generic;
namespace SnowSharp
{
    public static class FileSystem
    {

        /// <summary>
        /// 表示一个文件源
        /// </summary>
        static List<ISource> sources= new List<ISource>();
        public interface ISource
        {
            /// <summary>
            /// 从源中打开文件，如果未能打开则返回null
            /// </summary>
            /// <param name="path">文件路径</param>
            /// <returns>需要实现如果找到文件则返回一个可读流，否则返回null。</returns>
            Stream OpenFile(string path);
        }
        /// <summary>
        ///	添加一个源
        /// </summary>
        /// <param name="src">文件路径</param>
        public static void AddSource(ISource src)
        {
            sources.Add(src);
        }
        /// <summary>
        /// 删除一个源
        /// </summary>
        /// <param name="src">要删除的文件源</param>
        public static void DeleteSource(ISource src)
        {
            sources.Remove(src);
        }

        /// <summary>
        /// 找到一个文件源并返回
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>打开文件</returns>
        public static Stream OpenFile(string path)
        {
            Stream s = null;
            foreach(var src in sources)
            {
                s = src.OpenFile(path);
                if (s != null) break;
            }

            if (s == null) throw new FileNotFoundException();
            return s;
        }
    }
}
