using System;

namespace SnowSharp.Math
{
    /// <summary>
    /// 存放各种数据类型的插值器
    /// </summary>
    public static class Mixers
    {


        /// <summary>
        /// double类型的插值器
        /// </summary>
        public static readonly Func<double, double, double, double> DoubleMixer = (begin, end, per) => (end - begin) * per + begin;


        /// <summary>
        /// Vector2d型操作数
        /// </summary>
        public static readonly Func<OpenTK.Vector2d, OpenTK.Vector2d, double, OpenTK.Vector2d> Vector2dMixer = (begin, end, per) => (end - begin) * per + begin;
    }


    /// <summary>
    /// 存放各种类型的曲线函数
    /// </summary>
    public static class Funcs
    {

        /// <summary>
        /// 正比例曲线
        /// </summary>
        public static readonly Func<double, double> Line = x => x;


        /// <summary>
        /// 二次曲线
        /// </summary>
        public static readonly Func<double, double> Twice = p => -p * p + 2 * p;


        /// <summary>
        /// 球面曲线
        /// </summary>
        public static readonly Func<double, double> Circle = x => System.Math.Sqrt(1 - (x - 1) * (x - 1));


        /// <summary>
        /// 正弦曲线
        /// </summary>
        public static readonly Func<double, double> Sin = x => System.Math.Sin(System.Math.PI / 2 * x);
    }
}
