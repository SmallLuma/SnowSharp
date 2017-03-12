using System;

namespace SnowSharp
{

    /// <summary>
    /// 延迟任务
    /// 将会为任务做一个延迟，延迟n帧后执行
    /// </summary>
    public class Task : ILogic
    {
        Action mAction;
        int mTimer;
        bool mDied;


        /// <summary>
        /// 延迟
        /// </summary>
        /// <param name="act">任务内容</param>
        /// <param name="time">时间</param>
        public Task(Action act, int time)
        {
            mTimer = time;
            mAction = act;
            mDied = false;
        }


        public void OnUpdate()
        {
            mTimer--;
            if (mTimer <= 0)
            {
                Do();
            }
        }

        /// <summary>
        /// 取消延迟直接执行
        /// </summary>
        public void Do()
        {
            mAction();
            mDied = true;
        }

        public bool Died
        {
            get
            {
                return mDied;
            }
        }
    }
}
