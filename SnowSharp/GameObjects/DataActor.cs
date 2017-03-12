using System;

namespace SnowSharp.GameObjects
{
    public class DataActor<T> : IGameObject
    {
        uint nowTime, allTime;
        T val, begin, end;

        readonly Func<T, T, double, T> mixer;
        Func<double,double> func = x => x;


        /// <summary>
        /// 创建DataActor并传入插值器
        /// </summary>
        /// <param name="vmixer"></param>
        public DataActor(Func<T, T, double, T> vmixer)
        {
            mixer = vmixer;
        }

        public bool Died
        {
            get
            {
                return nowTime >= allTime;
            }
        }

        public void OnDraw()
        {
        }


        /// <summary>
        /// 开始进行自动插值
        /// </summary>
        /// <param name="vbegin">起始值</param>
        /// <param name="vend">结束值</param>
        /// <param name="time">消耗时间</param>
        public void Begin(T vbegin, T vend, uint time)
        {
            begin = vbegin;
            end = vend;
            allTime = time;
            nowTime = 0;
        }

        public void Begin(T vend,uint time)
        {
            begin = val;
            end = vend;
            allTime = time;
            nowTime = 0;
        }

        /// <summary>
        /// 插值器使用的变化曲线
        /// </summary>
        /// <param name="vfunc">变化曲线</param>
        public void SetFunc(Func<double, double> vfunc)
        {
            func = vfunc;
        }


        /// <summary>
        /// 当前插值器的值
        /// </summary>
        public T Value
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }

        public void OnUpdate()
        {
            if (!Died)
            {
                nowTime++;
                double per = func((double)nowTime / allTime);
                val = mixer(begin, end, per);
            }
        }

    }
}
