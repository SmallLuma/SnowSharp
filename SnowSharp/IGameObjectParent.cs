using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnowSharp
{

    /// <summary>
    /// 可访问的父结点
    /// </summary>
    public interface IGameObjectParent
    {
        /// <summary>
        /// 用于遍历的迭代器
        /// </summary>
        /// <returns>返回迭代器</returns>
        IEnumerator<GameObject> GetEnumerator();

        /// <summary>
        /// 按照类型进行搜索，返回搜到的第一个物体
        /// 用于ECS的Component获取
        /// </summary>
        /// <typeparam name="T">物体类型</typeparam>
        /// <returns></returns>
        T Get<T>()
            where T : GameObject;


        /// <summary>
        /// 搜索第一个和谓词匹配的物体
        /// </summary>
        /// <param name="func">谓词</param>
        /// <returns></returns>
        GameObject Get(Predicate<GameObject> func);


        /// <summary>
        /// 搜索全部匹配谓词的物体
        /// </summary>
        /// <param name="func">谓词</param>
        /// <returns></returns>
        IList<GameObject> GetAll(Predicate<GameObject> func);
    }
}
