using System;

namespace SnowSharp.GameObjects
{

    /// <summary>
    /// 延迟任务
    /// 将会为任务做一个延迟，延迟n帧后执行
    /// </summary>
    public class Task : GameObject
    {
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


        /// <summary>
        /// 取消延迟直接执行
        /// </summary>
        public void Do()
        {
            mAction();
            mDied = true;

            RemoveSelfFromParent();
        }


        #region override

        public override void OnUpdate()
        {
            mTimer--;
            if (mTimer <= 0)
            {
                Do();
            }
        }

        public override bool Died
        {
            get
            {
                return mDied;
            }
        }

        #endregion

        #region private

        Action mAction;
        int mTimer;
        bool mDied;

        #endregion

    }
}
