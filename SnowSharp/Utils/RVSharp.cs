using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SnowSharp.Utils
{

    /// <summary>
    /// RVSharp是RV的升级版
    /// 它是一种配置文件
    /// 具体的语法如下：
    /// key_value ::= key = val
    /// key_value_string :: = key = "val"
    /// 使用#号作为单行注释起始符号
    /// </summary>
    public class RVSharp
    {

        /// <summary>
        /// 创建RVS阅读器
        /// </summary>
        /// <param name="path">RVS文件路径</param>
        public RVSharp(string path)
        {
            parseRVSharp(new StreamReader(FileSystem.OpenFile(path)));
        }


        /// <summary>
        /// 根据键获取一个值
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            string value;
            bool good = key_values.TryGetValue(key.ToUpper(), out value);
            if (!good) throw new ValueNotFound(key);
            return (T)Convert.ChangeType(value, typeof(T));
        }


        /// <summary>
        /// 未找键对应到值
        /// </summary>
        public class ValueNotFound : Exception
        {
            string keyNotFound;
            public ValueNotFound(string key)
                : base(key + " Not found.")
            {
                keyNotFound = key;

            }

            public string Key
            {
                get
                {
                    return keyNotFound;
                }

                set
                {
                    keyNotFound = value;
                }
            }
        }

        /// <summary>
        /// 无法解析RVS文件
        /// </summary>
        public class ParseFailed : Exception
        {
            public ParseFailed(string e)
                : base(e) { }
        }

        Dictionary<string, string> key_values = new Dictionary<string, string>();

        void parseRVSharp(StreamReader stream)
        {
            while (stream.Peek() != -1)
            {
                string line = stream.ReadLine();

                line += '#';
                line = line.Substring(0, line.IndexOf('#'));

                line = line.Trim();

                if (line.Length == 0) continue;

                int eq = line.IndexOf('=');

                string key = line.Substring(0, eq);
                key = key.Trim();
                key = key.ToUpper();

                if (key_values.ContainsKey(key))
                    throw new ParseFailed("Key " + key + " is already exists.");

                if (eq + 1 >= line.Length)
                    throw new ParseFailed("Unknown error in line:" + line);

                string value = line.Substring(eq + 1);
                value = value.Trim();

                if (value.Length >= 1)
                {
                    if (value[0] == '\"')
                    {
                        int end = value.IndexOf('\"', 1);
                        value = value.Substring(1, end - 1);
                    }
                }

                key_values[key] = value;
            }
        }
    }
}
