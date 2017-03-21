using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnowSharp.Util
{

    /// <summary>
    /// CSV表格阅读器
    /// </summary>
    public class CSVReader
    {

        /// <summary>
        /// 从一个CSV文件创建CSV阅读器
        /// </summary>
        /// <param name="path">文件路径</param>
        public CSVReader(string path)
        {

        }

        /// <summary>
        /// 获取下一个单元格
        /// </summary>
        /// <typeparam name="T">要获取的类型</typeparam>
        /// <returns>获取到的值</returns>
        public T Pop<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当前行是否结束
        /// </summary>
        /// <returns>指示行是否结束的值</returns>
        public bool LineEnd()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 跳到下一行
        /// </summary>
        public void NextLine()
        {

        }


        /// <summary>
        /// 整个表格是否结束
        /// </summary>
        /// <returns>指示表格是否结束的值</returns>
        public bool End()
        {
            throw new NotImplementedException();
        }
    }
}
