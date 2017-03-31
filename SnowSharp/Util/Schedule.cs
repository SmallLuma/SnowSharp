using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;


namespace SnowSharp.Util
{

    /// <summary>
    /// 计划
    /// 用于将一个任务安排到另一个线程
    /// </summary>
    public class Schedule
    {

        /// <summary>
        /// 添加计划
        /// </summary>
        /// <param name="action"></param>
        public void Add(Action action)
        {
            actions.Enqueue(action);
        }


        /// <summary>
        /// 执行计划
        /// </summary>
        public void Do()
        {

            while (actions.Count > 0)
            {
                if (actions.TryDequeue(out Action act))
                    act();
            }
            
        }

        #region private
        ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();
#endregion
    }
}
