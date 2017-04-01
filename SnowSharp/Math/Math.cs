using System;
using OpenTK;

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
        public static readonly Func<float, float, float, float> FloatMixer = (begin, end, per) => (end - begin) * per + begin;


        /// <summary>
        /// Vector2d型操作数
        /// </summary>
        public static readonly Func<Vector2, Vector2, float, Vector2> Vector2Mixer = (begin, end, per) => (end - begin) * per + begin;

        public static readonly Func<Box2, Box2, float, Box2> Box2Mixer = (begin, end, per) =>
           {
               Box2 ret;
               ret.Left = FloatMixer(begin.Left, end.Left, per);
               ret.Right = FloatMixer(begin.Right, end.Right, per);
               ret.Top = FloatMixer(begin.Top, end.Top, per);
               ret.Bottom = FloatMixer(begin.Bottom, end.Bottom, per);
               return ret;
           };
    }


    /// <summary>
    /// 存放各种类型的曲线函数
    /// </summary>
    public static class Funcs
    {

        /// <summary>
        /// 正比例曲线
        /// </summary>
        public static readonly Func<float, float> Line = x => x;


        /// <summary>
        /// 二次曲线
        /// </summary>
        public static readonly Func<float, float> Twice = p => -p * p + 2 * p;


        /// <summary>
        /// 球面曲线
        /// </summary>
        public static readonly Func<float, float> Circle = x => (float)System.Math.Sqrt(1 - (x - 1) * (x - 1));


        /// <summary>
        /// 正弦曲线
        /// </summary>
        public static readonly Func<float, float> Sin = x => (float)System.Math.Sin(System.Math.PI / 2 * x);
    }
}
