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
                string line = csvStream.ReadLine();
                
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
                
                forms.Add(cellOfLine);
            }
            if (forms.Count > 0) formsLine = forms[0];
            
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
        /// 当前行是否结束
        /// </summary>
        /// <returns>指示行是否结束的值</returns>
        public bool LineEnd()
        {

            if (nowCell == formsLine.Count) return true;
            return false;
        }

        /// <summary>
        /// 跳到下一行
        /// </summary>
        public void NextLine()
        {
            nowCell = 0;
            formsLine = forms[++nowLine];
        }


        /// <summary>
        /// 整个表格是否结束
        /// </summary>
        /// <returns>指示表格是否结束的值</returns>
        public bool IsLastLine()
        {
            if (nowLine == forms.Count - 1) return true;
            return false;
        }

        #region private

        List<List<string>> forms = new List<List<string>>();
        List<string> formsLine = new List<string>();
        int nowLine = 0, nowCell = 0;

        #endregion
    }
}
