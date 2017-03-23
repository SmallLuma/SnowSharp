using System;
using System.IO;
using System.Collections.Generic;
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
            StreamReader csvStream = new StreamReader(FileSystem.OpenFile(path));
            while(csvStream.Peek() != -1){
                string line = csvStream.ReadLine().Trim();
                if (line == string.Empty) continue;

                line += '#';
                line = line.Substring(0, line.IndexOf('#'));

                string[] cells = line.Split(',');
                List<string> cellOfLine = new List<string>();
                int end = cells.Length - 1;
                while (end >= 0 && cells[end] == "")
                    end--;
                for (int now = 0; now <= end; now++)
                {
                    cellOfLine.Add(cells[now]);
                }
               if(cellOfLine.Count>0)
                    forms.Add(cellOfLine);
             }
        }
        
        /// <summary>
        /// 获取下一个单元格
        /// </summary>
        /// <typeparam name="T">要获取的类型</typeparam>
        /// <returns>获取到的值</returns>
        public T Pop<T>()
        {
            return (T)Convert.ChangeType(formsLine[nowCell++],typeof(T));
        }

        /// <summary>
        /// 当前行是否已经结束
        /// </summary>
        public bool IsLineEnd
        {
            get
            {
                if (nowCell == formsLine.Count) return true;
                return false;
            }
        }

        /// <summary>
        /// 若有下一行 枚举取下一行并返回true
        /// </summary>
        public bool EnumLine()
        {
            if (nowLine + 1 <= forms.Count - 1)
            {
                formsLine = forms[++nowLine];
                nowCell = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 重置 重置后需使用EnumLine进行初始化
        /// </summary>
        public void Reset()
        {
            nowLine = -1;
            nowCell = 0;
        }

        #region private

        List<List<string>> forms = new List<List<string>>();
        List<string> formsLine;
        int nowLine = -1, nowCell = 0;

        #endregion
    }
}
