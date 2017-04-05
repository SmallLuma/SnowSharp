using System;
using SnowSharp.Math;

namespace SnowSharp.GameObjects
{

    /// <summary>
    /// 自动插值器
    /// 用于将一个值随时间变换到另一个值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class DataActor<T> : GameObject
    {

        /// <summary>
        /// 创建DataActor并传入插值器
        /// </summary>
        /// <param name="vmixer"></param>
        public DataActor(Mixers.Mixer<T> vmixer)
        {
            mixer = vmixer;
        }


        /// <summary>
        /// 开始进行自动插值
        /// </summary>
        /// <param name="vbegin">起始值</param>
        /// <param name="vend">结束值</param>
        /// <param name="time">消耗时间</param>
        public void Begin(T vbegin, T vend, uint time)
        {
            Stop();
            begin = vbegin;
            end = vend;
            allTime = time;
            nowTime = 0;
        }


        /// <summary>
        /// 从当前值开始自动插值
        /// </summary>
        /// <param name="vend">结束值</param>
        /// <param name="time">消耗时间</param>
        public void Begin(T vend, uint time)
        {
            Stop();
            begin = val;
            end = vend;
            allTime = time;
            nowTime = 0;
        }


        /// <summary>
        /// 插值器使用的变化曲线
        /// </summary>
        /// <param name="vfunc">变化曲线</param>
        public Funcs.FuncLine Function
        {
            get => func;
            set => func = value;
        }


        /// <summary>
        /// 当前插值器的值
        /// </summary>
        public T Value
        {
            get => val;
            set => val = value;
        }


        /// <summary>
        /// 停止当前的插值并保持当前值
        /// </summary>
        public void Stop()
        {
            nowTime = allTime;
        }


        #region override

        public override bool Died
        {
            get
            {
                return nowTime >= allTime;
            }
        }

        public override void OnUpdate()
        {
            if (!Died)
            {
                nowTime++;
                float per = func((float)nowTime / allTime);
                val = mixer(begin, end, per);
            }
        }

        #endregion

        #region private

        uint nowTime, allTime;
        T val, begin, end;

        readonly Mixers.Mixer<T> mixer;
        Funcs.FuncLine func = x => x;

        #endregion
    }
}
